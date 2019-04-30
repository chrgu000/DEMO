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
    public partial class FrmProcessOrder : FrameBaseFunction.Frm�б���ģ��
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

                txtջ��1.Enabled = true;
                txtջ��2.Enabled = true;
                txtջ��3.Enabled = true;
                txtջ��4.Enabled = true;
                txtջ��5.Enabled = true;
                txtջ��6.Enabled = true;
                txtջ��7.Enabled = true;
                txtջ��1.Properties.ReadOnly = false;
                txtջ��2.Properties.ReadOnly = false;
                txtջ��3.Properties.ReadOnly = false;
                txtջ��4.Properties.ReadOnly = false;
                txtջ��5.Properties.ReadOnly = false;
                txtջ��6.Properties.ReadOnly = false;
                txtջ��7.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�\n\tԭ��" + ee.Message);
            }
        }

        /// <summary>
        /// ���ί��ӹ��̶�����Ϣ
        /// </summary>
        private void GetGridView()
        {
            try
            {
                string sSQL = "select * from UFDLImport.._Code where vchrType = '1' order by iOrder";
                DataTable dtջ�� = clsSQLCommond.ExecQuery(sSQL);
                if (dtջ�� == null || dtջ��.Rows.Count < 1)
                {
                    throw new Exception("��Ǽ�ջ�嵵��");
                }
                for (int i = 0; i < dtջ��.Rows.Count; i++)
                { 
                    string svchrInfo = dtջ��.Rows[i]["vchrInfo"].ToString().Trim();
                    if (labelջ��1.Name == "label" + svchrInfo)
                    {
                        labelջ��1.Visible = true;
                        txtջ��1.Visible = true;
                        labelջ��1.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��2.Name == "label" + svchrInfo)
                    {
                        labelջ��2.Visible = true;
                        txtջ��2.Visible = true;
                        labelջ��2.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��3.Name == "label" + svchrInfo)
                    {
                        labelջ��3.Visible = true;
                        txtջ��3.Visible = true;
                        labelջ��3.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��4.Name == "label" + svchrInfo)
                    {
                        labelջ��4.Visible = true;
                        txtջ��4.Visible = true;
                        labelջ��4.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��5.Name == "label" + svchrInfo)
                    {
                        labelջ��5.Visible = true;
                        txtջ��5.Visible = true;
                        labelջ��5.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��6.Name == "label" + svchrInfo)
                    {
                        labelջ��6.Visible = true;
                        txtջ��6.Visible = true;
                        labelջ��6.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��7.Name == "label" + svchrInfo)
                    {
                        labelջ��7.Visible = true;
                        txtջ��7.Visible = true;
                        labelջ��7.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��8.Name == "label" + svchrInfo)
                    {
                        labelջ��8.Visible = true;
                        txtջ��8.Visible = true;
                        labelջ��8.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��9.Name == "label" + svchrInfo)
                    {
                        labelջ��9.Visible = true;
                        txtջ��9.Visible = true;
                        labelջ��9.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (labelջ��10.Name == "label" + svchrInfo)
                    {
                        labelջ��10.Visible = true;
                        txtջ��10.Visible = true;
                        labelջ��10.Text = dtջ��.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                }


                if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
                {
                    sSQL = "@u8._GetProcessOrder '" + txtVenCode.Text.ToString().Trim() + "'";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
       
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //DateTime d�ƻ��������� = Convert.ToDateTime(dt.Rows[i]["�ƻ���������"]);
                        //DateTime d�ƻ��������� = Convert.ToDateTime(dt.Rows[i]["�ƻ���������"]);


                        //TimeSpan ts = d�ƻ��������� - d�ƻ���������; 
                        //int iDay = ts.Days;

                        int iDay�ƻ� = ReturnObjectToInt(dt.Rows[i]["�ƻ�ί������"]);
                        int i���� = ReturnObjectToInt(dt.Rows[i]["iInvAdvance"]);

                        if (i���� < iDay�ƻ�)
                        {
                            dt.Rows[i]["�Ƿ�ѹ������"] = 1;
                        }
                        else
                        {
                            dt.Rows[i]["�Ƿ�ѹ������"] = 0;
                        }
                    }


                    DataView dv = dt.DefaultView;

                    dv.Sort = "MODetailsID";

                    string sFilter = " 1=1 ";
                    if (chkAllow.Checked)
                    {
                        sFilter = sFilter + " and cdefine35 is not null";
                    }
                    if (!chk��AK����.Checked)
                    {
                        sFilter = sFilter + " and cCode not like 'AK%' ";
                    }
                    dv.RowFilter = sFilter;

                    gridControl1.DataSource = dv;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ί��ӹ�����Ϣʧ�ܣ�\n\tԭ��" + ee.Message);
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
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                {
                    sSQL = "update @u8.OM_MODetails set cbCloser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dbclosetime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dbcloseDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where MODetailsID = " + gridView1.GetRowCellValue(i, gridColumn9).ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("�Ƿ�ȷ�Ϲرգ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("�رճɹ���");
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
                sa.Filter = "Excel�ļ�2003|*.xls";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                }
            }
            catch (Exception ee)
            { 
                throw new Exception("����Excelʧ�ܣ�" + ee.Message);
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
                                dr["Column9"] = "�� " + iRow;
                            if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "3")
                                dr["Column9"] = "�� " + iRow;

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
                dRowTe["Column2"] = "��Ӧ�̣�" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                dRowTe["Column3"] = "�Ƶ����ڣ�" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "�Ƶ���:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dRowTe["Column5"] = "�����ϼƣ�" + dQTY.ToString().Trim();
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش�ӡʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            throw new Exception("��" + (i + 1).ToString() + "�����������0");
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
                            dr["Column9"] = "�� " + iRow;
                        if (dt.Rows[i]["DType"].ToString().Trim().ToString().Trim() == "3")
                            dr["Column9"] = "�� " + iRow;

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

                #region �ǼǴ�ӡ
                
                long iջ��1 = ReturnObjectToLong(txtջ��1.Text.Trim());
                long iջ��2 = ReturnObjectToLong(txtջ��2.Text.Trim());
                long iջ��3 = ReturnObjectToLong(txtջ��3.Text.Trim());
                long iջ��4 = ReturnObjectToLong(txtջ��4.Text.Trim());
                long iջ��5 = ReturnObjectToLong(txtջ��5.Text.Trim());
                long iջ��6 = ReturnObjectToLong(txtջ��6.Text.Trim());
                long iջ��7 = ReturnObjectToLong(txtջ��7.Text.Trim());
                long iջ��8 = ReturnObjectToLong(txtջ��8.Text.Trim());
                long iջ��9 = ReturnObjectToLong(txtջ��9.Text.Trim());
                long iջ��10 = ReturnObjectToLong(txtջ��10.Text.Trim());

                string sGuid = Guid.NewGuid().ToString();
                string sSQL = "insert into UFDLImport..ջ���ӡ�Ǽ�(GUID, ��������,  ջ��1, ջ��2, ջ��3, ջ��4, ջ��5, ջ��6, ջ��7, ջ��8, ջ��9, ջ��10,����)" +
                    "values('" + sGuid + "','ί�⵽��'," + iջ��1 + "," + iջ��2 + "," + iջ��3 + "," + iջ��4 + "," + iջ��5 + "," + iջ��6 + "," + iջ��7 + "," + iջ��8 + "," + iջ��9 + "," + iջ��10 + "," + rep.dataSet1.Tables[0].Rows.Count + ")";
                clsSQLCommond.ExecSql(sSQL);

                sSQL = "select * from UFDLImport..ջ���ӡ�Ǽ� where GUID = '" + sGuid + "'";
                DataTable dtջ���ӡ�Ǽ� = clsSQLCommond.ExecQuery(sSQL);
                string sIDջ���ӡ�Ǽ� = "";
                if (dtջ���ӡ�Ǽ� != null && dtջ���ӡ�Ǽ�.Rows.Count > 0)
                    sIDջ���ӡ�Ǽ� = dtջ���ӡ�Ǽ�.Rows[0]["iID"].ToString().Trim();

                #endregion

                DataTable dt2 = rep.dataSet1.Tables[1];
                DataRow dRowTe = dt2.NewRow();
                dRowTe["Column1"] = rep.dataSet1.Tables[0].Rows.Count;
                dRowTe["Column2"] = "��Ӧ�̣�" + txtVenCode.Text.Trim() + "--" + txtVenName.Text.Trim();
                dRowTe["Column3"] = "�Ƶ����ڣ�" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy-MM-dd");
                dRowTe["Column4"] = "�Ƶ���:" + FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dRowTe["Column5"] = "�����ϼƣ�" + dQTY.ToString().Trim();

                string sջ�� = "";
                if (ReturnObjectToLong(txtջ��1.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��1.Text + "[  " + txtջ��1.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��2.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��2.Text + "[  " + txtջ��2.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��3.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��3.Text + "[  " + txtջ��3.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��4.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��4.Text + "[  " + txtջ��4.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��5.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��5.Text + "[  " + txtջ��5.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��6.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��6.Text + "[  " + txtջ��6.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��7.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��7.Text + "[  " + txtջ��7.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��8.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��8.Text + "[  " + txtջ��8.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��9.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��9.Text + "[  " + txtջ��9.Text.Trim() + "  ]  ";
                }
                if (ReturnObjectToLong(txtջ��10.Text.Trim()) > 0)
                {
                    sջ�� = sջ�� + labelջ��10.Text + "[  " + txtջ��10.Text.Trim() + "  ]  ";
                }
                dRowTe["Column11"] = sջ��;
                dRowTe["Column12"] = sIDջ���ӡ�Ǽ�;
                dt2.Rows.Add(dRowTe);

                rep.ShowPreview();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش�ӡʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("���������֣�");
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
                    //gridColiWIPtype ��������   1�� ���壻       3������

                    decimal dNow = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColumn5));
                    if (dNow < 0)
                    {
                        MessageBox.Show("����Ϊ��������˲飡");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }

                    decimal dδ��� = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiUnReceivedQTY));
                    if (dNow > dδ��� && dNow != 0)
                    {
                        MessageBox.Show("��������������˲飡");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }

                    if (gridView1.GetRowCellValue(e.RowHandle, gridColiWIPtype).ToString().Trim() != "1" && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) > Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiUnReceivedQTY)))
                    {                     
                        MessageBox.Show("���ò��ϲ��㷢������˲飡");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn15))*(1 +Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess)))  < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn5)) + Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn17)))
                    {
                        MessageBox.Show("���������Ѿ���������˲飡");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn16))*(1 +Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess)))  < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn18)) + Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("���������Ѿ���������˲飡");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn5, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }
                }
                if (e.Column == gridColumn11)
                {

                    if (!ChkNumber(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("���������֣�");
                        gridView1.SetRowCellValue(e.RowHandle, gridColumn11, "");
                        return;
                    }


                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn10)) < Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColumn11)))
                    {
                        MessageBox.Show("���������Ѿ���������˲飡");
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
                    if (e.Column == gridCol�������)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(e.RowHandle, gridCol�������)))
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
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
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
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
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

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() != "��")
                {
                    gridView1.SetRowCellValue(iRow, gridColbChoose, "��");
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