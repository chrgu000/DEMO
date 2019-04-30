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
    public partial class FrmProcessOrderReturn : FrameBaseFunction.Frm�б���ģ��
    {
        public FrmProcessOrderReturn()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "addrow":
                        btnSave();
                        break;
                    case "import":
                        btnAudit();
                        break;
                    case "add":
                        btnUnAudit();
                        break;
                    case "delrow":
                        btnApply();
                        break;
                    case "edit":
                        btnAlteration();
                        break;
                    case "del":
                        btnExport();
                        break;
                    case "save":
                        btnPrint();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "audit":
                        btnsAudit();
                        break;
                    case "unaudit":
                        btnsDAudit();
                        break;
                    case "open":
                        btnsDAudit2();
                        break;
                    default:
                        break;
                    //case "sel":
                    //    btnSel();
                    //    break;
                    //case "save":
                    //    btnSave();
                    //    break;
                    //case "audit":
                    //    btnAudit();
                    //    break;
                    //case "unaudit":
                    //    btnUnAudit();
                    //    break;
                    //case "apply":
                    //    btnApply();
                    //    break;
                    //case "alteration":
                    //    btnAlteration();
                    //    break;
                    //case "export":
                    //    btnExport();
                    //    break;
                    //case "print":
                    //    btnPrint();
                    //    break;
                    //case "unlock":
                    //    btnUnLock();
                    //    break;
                    //case "lock":
                    //    btnLock();
                    //    break;
                    //case "saudit":
                    //    btnsAudit();
                    //    break;
                    //case "sdaudit":
                    //    btnsDAudit();
                    //    break;
                    //case "sdaudit2":
                    //    btnsDAudit2();
                    //    break;
                    //default:
                    //    break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ���ܻظ�����ȷ��
        /// </summary>
        private void btnsDAudit()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("����˵��ݲ��ָܻ�������");
                        return;
                    }

                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    string sErr = "";
                    ArrayList aList = new ArrayList();
                    string sSQL = "";

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                        {
                            if (gridView2.GetRowCellValue(i, gridCol��������ȷ����).ToString().Trim() == "")
                            {
                                sErr = sErr + "��" + (i + 1) + "û�����룬����ȷ��\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..OM_MODetails_Import set ���ܻظ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',���ܻظ�ʱ��= GETDATE(),���ܻظ���� = '" + gridView2.GetRowCellValue(i, gridCol���ܻظ����).ToString().Trim() + "',���ܾܾ� = 0 " +
                                   "where MODetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);

                            if (radioApply.Checked)    //���λ�ǩ
                            {
                                if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                                {
                                    sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����2δ��д����ȷ\n";
                                    continue;
                                }

                                if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                {
                                    sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����2�������ڵ�¼����\n";
                                    continue;
                                }

                                sSQL = "update UFDLImport..OM_MODetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',returndate2='" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bAgain = 1 " +
                                       "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                gridView2.SetRowCellValue(i, gridColbAgain, "��");

                                sSQL = "update @u8.OM_MODetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);

                                aList.Add(sSQL);
                            }
                            else                      //һ�λ�ǩ
                            {

                                if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() != string.Empty)
                                {
                                    if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                    {
                                        sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����2�������ڵ�¼����\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                                    {
                                        sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����δ��д����ȷ\n";
                                        continue;
                                    }

                                    if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                    {
                                        sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ���ڲ������ڵ�¼����\n";
                                        continue;
                                    }
                                }
                                sSQL = "update UFDLImport..OM_MODetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                       "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();
                                if (iR == "��")
                                {
                                    sSQL = "update @u8.OM_MODetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                }
                                else
                                {
                                    sSQL = "update @u8.OM_MODetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                }
                                aList.Add(sSQL);
                            }
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        MsgBox("��ʾ", sErr);
                        return;
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("ȷ�ϳɹ���");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// ���ܻظ�
        /// </summary>
        private void btnsDAudit2()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("����˵��ݲ��ָܻ�������");
                        return;
                    }

                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    string sErr = "";
                    ArrayList aList = new ArrayList();
                    string sSQL = "";

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                        {
                            if (gridView2.GetRowCellValue(i, gridCol��������ȷ����).ToString().Trim() == "")
                            {
                                sErr = sErr + "��" + (i + 1) + "û�����룬����ȷ��\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..OM_MODetails_Import set ���ܻظ��� = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',���ܻظ�ʱ��= GETDATE(),���ܻظ���� = '" + gridView2.GetRowCellValue(i, gridCol���ܻظ����).ToString().Trim() + "',���ܾܾ� = 1 " +
                                   "where MODetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        MsgBox("��ʾ", sErr);
                        return;
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("�ظ��ɹ���");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// ��������ȷ��
        /// </summary>
        private void btnsAudit()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("����˵��ݲ��ָܻ�������");
                        return;
                    }

                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    ArrayList aList = new ArrayList();
                    string sSQL = "";

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                        {
                            sSQL = "update UFDLImport..OM_MODetails_Import set ��������ȷ���� = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',��������ȷ��ʱ��= GETDATE() " +
                                   "where MODetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);
                        }
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("�ɹ��ύ���룡");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLock()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        sSQL = "update UFDLImport..OM_MODetails_Import set UnLockTomatoUser = null,UnLockTomatoDate= null " +
                               "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("�ָ������ɹ���");

                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnLock()
        {
            try
            {
                if (radioUnSure.Checked)
                {
                    MessageBox.Show("��Ӧ����δȷ�ϣ�����Ҫ������");
                    return;
                }
                if (radioAudit.Checked)
                {
                    MessageBox.Show("�Ѿ���ˣ����ܽ�����");
                    return;
                }

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";

                
                #region ��������������

                int iChoose = 0;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        iChoose += 1;
                    }
                }
                if (iChoose != 1)
                {
                    MessageBox.Show("����ֻ��ѡ��һ��������ѡ��");
                    chkAll.Checked = false;
                    chkAll_CheckedChanged(null, null);
                    return;
                }
                #endregion
           

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        sSQL = "update UFDLImport..OM_MODetails_Import set UnLockTomatoUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',UnLockTomatoDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                               "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("�����ɹ���");

                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                }
                catch { }

                RepProcessOrderReturn2 rep = new RepProcessOrderReturn2();

                DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                int iRow = 0;
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;


                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        DataRow dr = dtDetail.NewRow();
                        dr["Column1"] = gridView2.GetRowCellValue(i, gridColcPOID).ToString().Trim();

                        if (gridView2.GetRowCellValue(i, gridColdPODate).ToString().Trim() != "")
                        {
                            dr["Column2"] = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColdPODate)).ToString("yyyy-MM-dd");
                        }

                        dr["Column3"] = gridView2.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        dr["Column4"] = gridView2.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                        dr["Column5"] = gridView2.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                        dr["Column6"] = gridView2.GetRowCellValue(i, gridColcItemCode).ToString().Trim();

                        if (gridView2.GetRowCellValue(i, gridColdArriveDate).ToString().Trim() != "")
                        {
                            dr["Column7"] = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColdArriveDate)).ToString("yyyy-MM-dd");
                        }
                        if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() != "")
                        {
                            dr["Column8"] = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)).ToString("yyyy-MM-dd");
                        }
                        if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() != "")
                        {
                            dr["Column9"] = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)).ToString("yyyy-MM-dd");
                        }
                        if (gridView2.GetRowCellValue(i, gridColiQuantity).ToString().Trim() != "")
                        {
                            dr["Column10"] = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQuantity));
                            d1 = d1 + Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQuantity));
                        }
                        if (gridView2.GetRowCellValue(i, gridColiNum).ToString().Trim() != "")
                        {
                            dr["Column11"] = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiNum));
                            d2 = d2 + Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiNum));
                        }
                        if (gridView2.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() != "")
                        {
                            dr["Column12"] = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiTaxPrice));
                        }
                        if (gridView2.GetRowCellValue(i, gridColiSum).ToString().Trim() != "")
                        {
                            dr["Column13"] = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiSum));
                            d3 = d3 + Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiSum));
                        }
                        iRow += 1;
                        dr["Column14"] = iRow;

                        dtDetail.Rows.Add(dr);
                    }
                }

                if (dtDetail.Rows.Count < 1)
                {
                    MessageBox.Show("��ѡ����Ҫ��ӡ�����ݣ�");
                    return;
                }

                DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                DataRow dRowTe = dtHead.NewRow();
                dRowTe["Column1"] = d1;
                dRowTe["Column2"] = d2;
                dRowTe["Column3"] = d3;
                dtHead.Rows.Add(dRowTe);

                rep.ShowPreview();

            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش�ӡʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "ί�⹩Ӧ��ȷ���б�";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView2.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnSel()
        {
            GetGridView();
        }

        private void btnAlteration()
        {
            try
            {
                string sText = "";
                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
                    {
                        sText = base.toolStripMenuBtn.Items[i].Text.Trim();
                        break;
                    }
                }
                if (sText == "���")
                {
                    gridColdArriveDate.OptionsColumn.AllowEdit = true;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "����";
                        }
                    }
                }
                ArrayList aList = new ArrayList();
                string sSQL = "";

                //ArrayList aListMail = new ArrayList();
                //aListMail.Add("delete _Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");

                if (sText == "����")
                {
                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                        {
                            sSQL = "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',bAgain=0,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null,ReturnDate1=null,ReturnDate2=null " +
                                         "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);

                            sSQL = "update @u8.OM_MODetails set dArriveDate = '" + gridView2.GetRowCellValue(i, gridColdArriveDate) + "',cDefine36 = null,cDefine37 = null where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                            aList.Add(sSQL);


                            //sSQL = "insert into _Table_TempTH(a1,a2,a3,a4,a5)values(N'" + sTempKey + "',N'" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                            //aListMail.Add(sSQL);
                        }
                    }
                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("����ɹ���");

                        //SendMail(aListMail, 4);

                        GetGridView();
                        gridColdArriveDate.OptionsColumn.AllowEdit = false;

                        for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                        {
                            if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                            {
                                base.toolStripMenuBtn.Items[i].Text = "���";
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ʧ�ܣ�  " + ee.Message);
            }
        }

        private void GetGridView()
        {
            try
            {

                string sSQL = "";
                if (txtVenCode.Enabled == true)
                {
                    gridCol���ܻظ����.Visible = true;
                    gridCol���ܻظ�ʱ��.Visible = true;
                    gridCol���ܻظ�����.Visible = true;
                    gridCol���ܻظ���.Visible = true;
                    gridCol��������ȷ��ʱ��.Visible = true;
                    gridCol��������ȷ������.Visible = true;
                    gridCol��������ȷ����.Visible = true;

                    gridCol�˻�����.Visible = true;
                    gridCol�˻�����.Visible = true;

                    if (radioUnSure.Checked)
                    {
                        sSQL = @"
select min(c.�ƻ���������) as �ƻ���������,a.���۶�����,g.InvCode as �Ӽ�����
into #a
from XWSystemDB_DL.dbo.�����ƻ� a inner join XWSystemDB_DL.dbo.�����ƻ���ϸ b on a.���ݺ� = b.��ͷ���ݺ�
    inner join XWSystemDB_DL.dbo.�����ռƻ� c on b.iID = c.�����ƻ���ϸiID
    inner join @u8.bas_part d on d.InvCode = b.���ϱ���
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
group by a.���۶�����,g.InvCode

select min(c.�ƻ���������) as �ƻ���������,a.���۶�����,g.InvCode as �Ӽ�����
into #b
from XWSystemDB_DL.dbo.�����ƻ� a inner join XWSystemDB_DL.dbo.�����ƻ���ϸ b on a.���ݺ� = b.��ͷ���ݺ�
    inner join XWSystemDB_DL.dbo.�����ռƻ� c on b.iID = c.�����ƻ���ϸiID
    inner join @u8.bas_part d on d.InvCode = b.���ϱ���
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
where c.�Ų����� = (select MAX(�Ų�����) from XWSystemDB_DL.dbo.�����ռƻ�)
group by a.���۶�����,g.InvCode


select distinct ReturnRemark,(case isnull(bAgain,0) when 1 then '��' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose, 
            ps.MODetailsID as [ID],p.cCode as cPOID,dDate as dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity, 
            ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.MODetailsID as [id],  
            (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2, 
            pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode, 
            d.cDepName,(case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
            (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, 
            (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,e.�ƻ��������� as ���ڼƻ�����,f.�ƻ��������� as �����ƻ���������,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate  
             ,��������ȷ����, ��������ȷ��ʱ��, ���ܻظ���, ���ܻظ�ʱ��, ���ܻظ���� 
            , ps.cDefine24 as �ƻ�Ա,ps.cDefine25 as ��һ���� 
            ,isnull(g.�������,0) as �������
            ,h.�˻�����,h.iQty as �˻�����
from @u8.OM_MODetails ps inner join @u8.OM_MOMain p on p.MOID = ps.MOID 
            left join UFDLImport..OM_MODetails_Import pI on pI.MODetailsID = ps.MODetailsID and accid =  111111 and accyear = '222222'  
            left join @u8.Inventory I on I.cInvCode = ps.cInvCode   
            left join @u8.Vendor v on v.cVenCode = p.cVenCode  
            left join @u8.Department d on d.cDepCode = p.cDepCode    
            left join #a e on e.���۶����� = ps.cItemCode and e.�Ӽ����� = ps.cInvCode 
        left join #b f on f.���۶����� = ps.cItemCode and f.�Ӽ����� = ps.cInvCode 
   left join 
        (
	        select CAST(case when isnull(SUM(�������),0) = 0 then 0 else 1 end as bit) as �������,���۶�����
	        from XWSystemDB_DL.dbo.���������ܱ�
	        group by ���۶�����
        )g on g.���۶����� = ps.citemcode
    left join 
        (
            select  a.�˻�����,sum(b.iQuantity) as iQty,a.iPOsID,a.cVenCode
            from 
            (
	            select max(a.dDate) as �˻�����,b.iPOsID , b.cInvCode,a.cVenCode
	            from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id
	            where ISNULL(b.iQuantity,0) < 0 
		            and a.cPTCode = '02'
	            group by b.iPOsID  , b.cInvCode,a.cVenCode
            ) a inner join 
            (
	            select a.dDate,a.cVenCode,b.iQuantity,b.iPOsID , b.cInvCode from  @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where a.cPTCode = '02' and ISNULL(b.iQuantity,0) < 0 
            ) b on a.iPOsID = b.iPOsID and a.�˻����� = b.dDate and a.cInvCode = b.cInvCode and a.cVenCode = b.cVenCode
            group by a.�˻�����,a.iPOsID,a.cVenCode
        )h on h.iPOsID = ps.MODetailsID
where  iVerifyStateNew = 2 and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) 
";

                        sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                        sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                    }
                    else
                    {
                        sSQL = @"

select min(c.�ƻ���������) as �ƻ���������,a.���۶�����,g.InvCode as �Ӽ�����
into #a
from XWSystemDB_DL.dbo.�����ƻ� a inner join XWSystemDB_DL.dbo.�����ƻ���ϸ b on a.���ݺ� = b.��ͷ���ݺ�
            inner join XWSystemDB_DL.dbo.�����ռƻ� c on b.iID = c.�����ƻ���ϸiID
            inner join @u8.bas_part d on d.InvCode = b.���ϱ���
            inner join @u8.bom_parent e on e.ParentId = d.PartId
            inner join @u8.bom_opcomponent f on f.BomId = e.BomId
            inner join @u8.bas_part g on g.PartId = f.ComponentId
group by a.���۶�����,g.InvCode

select min(c.�ƻ���������) as �ƻ���������,a.���۶�����,g.InvCode as �Ӽ�����
into #b
from XWSystemDB_DL.dbo.�����ƻ� a inner join XWSystemDB_DL.dbo.�����ƻ���ϸ b on a.���ݺ� = b.��ͷ���ݺ�
    inner join XWSystemDB_DL.dbo.�����ռƻ� c on b.iID = c.�����ƻ���ϸiID
    inner join @u8.bas_part d on d.InvCode = b.���ϱ���
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
where c.�Ų����� = (select MAX(�Ų�����) from XWSystemDB_DL.dbo.�����ռƻ�)
group by a.���۶�����,g.InvCode


select distinct ReturnRemark,(case isnull(bAgain,0) when 1 then '��' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose, 
        ps.MODetailsID as [ID],p.cCode as cPOID,dDate as dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity, 
        ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.MODetailsID as [id],  
        (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2, 
        pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode, 
        d.cDepName,(case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate , 
        (ps.iQuantity - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, 
        (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn2, 
        (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,e.�ƻ��������� as ���ڼƻ�����,f.�ƻ��������� as �����ƻ���������,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate  
         ,��������ȷ����, ��������ȷ��ʱ��, ���ܻظ���, ���ܻظ�ʱ��, ���ܻظ���� 
        , ps.cDefine24 as �ƻ�Ա,ps.cDefine25 as ��һ���� 
        ,isnull(g.�������,0) as �������
        ,h.�˻�����,h.iQty as �˻�����
from @u8.OM_MODetails ps inner join @u8.OM_MOMain p on p.MOID = ps.MOID 
        left join UFDLImport..OM_MODetails_Import pI on pI.MODetailsID = ps.MODetailsID and accid =  111111 and accyear = '222222'  
        left join @u8.Inventory I on I.cInvCode = ps.cInvCode   
        left join @u8.Vendor v on v.cVenCode = p.cVenCode  
        left join #a e on e.���۶����� = ps.cItemCode and e.�Ӽ����� = ps.cInvCode 
        left join #b f on f.���۶����� = ps.cItemCode and f.�Ӽ����� = ps.cInvCode 
     left join @u8.Department d on d.cDepCode = p.cDepCode    
   left join 
        (
	        select CAST(case when isnull(SUM(�������),0) = 0 then 0 else 1 end as bit) as �������,���۶�����
	        from XWSystemDB_DL.dbo.���������ܱ�
	        group by ���۶�����
        )g on g.���۶����� = ps.citemcode
    left join 
        (
            select  a.�˻�����,sum(b.iQuantity) as iQty,a.iPOsID,a.cVenCode
            from 
            (
	            select max(a.dDate) as �˻�����,b.iPOsID , b.cInvCode,a.cVenCode
	            from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id
	            where ISNULL(b.iQuantity,0) < 0 
		            and a.cPTCode = '02'
	            group by b.iPOsID  , b.cInvCode,a.cVenCode
            ) a inner join 
            (
	            select a.dDate,a.cVenCode,b.iQuantity,b.iPOsID , b.cInvCode from  @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where a.cPTCode = '02' and ISNULL(b.iQuantity,0) < 0 
            ) b on a.iPOsID = b.iPOsID and a.�˻����� = b.dDate and a.cInvCode = b.cInvCode and a.cVenCode = b.cVenCode
            group by a.�˻�����,a.iPOsID,a.cVenCode
        )h on h.iPOsID = ps.MODetailsID
where  iVerifyStateNew = 2 
";
                        if (!chkAllRow.Checked)
                        {
                            sSQL = sSQL + "  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) ";
                        }

                        sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                        sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));

                    }
                }
                else
                {
                    gridCol���ܻظ����.Visible = false;
                    gridCol���ܻظ�ʱ��.Visible = false;
                    gridCol���ܻظ�����.Visible = false;
                    gridCol���ܻظ���.Visible = false;
                    gridCol��������ȷ��ʱ��.Visible = false;
                    gridCol��������ȷ������.Visible = false;
                    gridCol��������ȷ����.Visible = false;

                    gridCol�˻�����.Visible = false;
                    gridCol�˻�����.Visible = false;

                    if (radioUnSure.Checked)
                    {
                        sSQL = @"
select distinct ReturnRemark,(case isnull(bAgain,0) when 1 then '��' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose, 
        ps.MODetailsID as [ID],p.cCode as cPOID,dDate as dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity, 
        ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.MODetailsID as [id],  
        (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2, 
        pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode, 
        d.cDepName,(case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
        (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, 
        (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate 
         ,��������ȷ����, ��������ȷ��ʱ��, ���ܻظ���, ���ܻظ�ʱ��, ���ܻظ���� 
        , ps.cDefine24 as �ƻ�Ա,ps.cDefine25 as ��һ���� 
            ,isnull(g.�������,0) as �������
from @u8.OM_MODetails ps inner join @u8.OM_MOMain p on p.MOID = ps.MOID 
        left join UFDLImport..OM_MODetails_Import pI on pI.MODetailsID = ps.MODetailsID and accid =  111111 and accyear = '222222'  
        left join @u8.Inventory I on I.cInvCode = ps.cInvCode   
        left join @u8.Vendor v on v.cVenCode = p.cVenCode 
        left join @u8.Department d on d.cDepCode = p.cDepCode  
        left join 
        (
	        select CAST(case when isnull(SUM(�������),0) = 0 then 0 else 1 end as bit) as �������,���۶�����
	        from XWSystemDB_DL.dbo.���������ܱ�
	        group by ���۶�����
        )g on g.���۶����� = ps.citemcode  
where  iVerifyStateNew = 2 and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) ";

                                   
    sSQL = sSQL.Replace("111111",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                    }
                    else
                    {
                        sSQL = @"
select distinct ReturnRemark,(case isnull(bAgain,0) when 1 then '��' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose, 
        ps.MODetailsID as [ID],p.cCode as cPOID,dDate as dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity, 
        ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.MODetailsID as [id],  
        (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2, 
        pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode, 
        d.cDepName,(case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate , 
        (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, 
        (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate 
         ,��������ȷ����, ��������ȷ��ʱ��, ���ܻظ���, ���ܻظ�ʱ��, ���ܻظ���� 
        , ps.cDefine24 as �ƻ�Ա,ps.cDefine25 as ��һ���� 
            ,isnull(g.�������,0) as �������
from @u8.OM_MODetails ps inner join @u8.OM_MOMain p on p.MOID = ps.MOID 
        left join UFDLImport..OM_MODetails_Import pI on pI.MODetailsID = ps.MODetailsID and accid =  111111 and accyear = '222222'  
        left join @u8.Inventory I on I.cInvCode = ps.cInvCode   
        left join @u8.Vendor v on v.cVenCode = p.cVenCode  
        left join @u8.Department d on d.cDepCode = p.cDepCode   
        left join 
        (
            select CAST(case when isnull(SUM(�������),0) = 0 then 0 else 1 end as bit) as �������,���۶�����
            from XWSystemDB_DL.dbo.���������ܱ�
            group by ���۶�����
        )g on g.���۶����� = ps.citemcode
where  iVerifyStateNew = 2 ";

                                   
    sSQL = sSQL.Replace("111111",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                        if (!chkAllRow.Checked)
                        {
                            sSQL = sSQL + "  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) ";
                        }

                    }
                }

                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioδ����.Checked)
                    {
                        sSQL = sSQL + " and isnull(��������ȷ����,'') = '' and isnull(���ܻظ���,'') = '' ";
                    }
                    if (radio���ظ�.Checked)
                    {
                        sSQL = sSQL + " and (isnull(��������ȷ����,'') <> '' and isnull(���ܻظ���,'') = '' or isnull(���ܾܾ�,0) = 1) ";
                    }
                    if (radio�ѻظ�.Checked)
                    {
                        sSQL = sSQL + " and isnull(��������ȷ����,'') <> '' and isnull(���ܻظ���,'') <> '' ";
                    }
                }


                if (txtDepName.Text.Trim() != "")
                {
                    sSQL = sSQL + "  and  p.cDepCode = '" + txtDepCode.Text.Trim() + "' ";
                }

                if (txtVenCode.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + "  and p.cVenCode = '" + txtVenCode.Text.Trim() + "' ";
                }

                if (radioAudit.Checked)
                    sSQL = sSQL + "  and isnull(ReturnApply,0) <> 1  "; //and isnull(ReturnAudit,0) = 1
                if (radioUnSure.Checked)
                    sSQL = sSQL + " and  isnull(ReturnAudit,0) <> 1  and  pI.ReturnDate1 is null ";

                if (radioEnSure.Checked)
                    sSQL = sSQL + " and isnull(ReturnAudit,0) <> 1 and  pI.ReturnDate1 is not null and isnull(ReturnApply,0) = 0 ";
                if (radioApply.Checked)
                    sSQL = sSQL + " and isnull(ReturnApply,0) = 1 and (isnull(ReturnAudit,0) = 1 or isnull(ReturnAudit,0) = 0) ";
                if (lookUpEditPOID1.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cCode >= '" + lookUpEditPOID1.Text.Trim() + "' ";
                }
                if (lookUpEditPOID2.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cCode <= '" + lookUpEditPOID2.Text.Trim() + "' ";
                }
                if (checkBox1.Checked)
                {
                    sSQL = sSQL + " and p.dDate >= '" + dateEdit1.Text.Trim() + "' and p.dDate <= '" + dateEdit2.Text.Trim() + "' ";
                }


                sSQL = sSQL + " order by p.cVenCode,ps.MODetailsID  ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (radioUnSure.Checked)
                {

                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    gridControl2.DataSource = null;
                }
                else
                {
                    gridControl2.DataSource = dt;

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        DateTime d1;
                        if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() != "")
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColReturnDate2).ToString()).ToString("yyyy-MM-dd"));
                        else if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() != "")
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColReturnDate1).ToString()).ToString("yyyy-MM-dd"));
                        else
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColdArriveDate).ToString()).ToString("yyyy-MM-dd"));

                        DateTime d2 = DateTime.Parse("2099-1-1");
                        DateTime d3 = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                        if (gridView2.GetRowCellValue(i, gridCol�����ƻ���������) != null && gridView2.GetRowCellValue(i, gridCol�����ƻ���������).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol�����ƻ���������).ToString()).ToString("yyyy-MM-dd"));
                        else if (gridView2.GetRowCellValue(i, gridCol���ڼƻ�����) != null && gridView2.GetRowCellValue(i, gridCol���ڼƻ�����).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol���ڼƻ�����).ToString()).ToString("yyyy-MM-dd"));

                        if (d1 > d2 || d1 < d3)
                        {
                            gridView2.SetRowCellValue(i, gridColbTomato, 1);
                        }
                        else
                        {
                            gridView2.SetRowCellValue(i, gridColbTomato, 0);
                        }

                        ///�д���֤
                        //if (d1 < d3)
                        //{
                        //    gridView2.SetRowCellValue(i, gridColbTomato, 2);
                        //}
                        //if (d1 > d2 || d2 < d3)
                        //{
                        //    gridView2.SetRowCellValue(i, gridColbTomato, 1);
                        //}
                    }
                    if (radioEnSure.Checked || radioApply.Checked)
                    {

                        ChecExistkWorkPlan();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����б�ʧ�ܣ�  " + ee.Message);
            }
        }

        /// <summary>
        /// �ٴ�ȷ������
        /// </summary>
        private void btnApply()
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                string sErr1 = "";
                string sErr2 = "";


                //ArrayList aListMail = new ArrayList();
                //aListMail.Add("delete _Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");


                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == "")
                        {
                            sErr1 = sErr1 + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                            continue;
                        }
                        if (radioAudit.Checked)
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnAudit).ToString().Trim() != "1")
                            {
                                sErr = sErr + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                                continue;
                            }
                            if (gridView2.GetRowCellValue(i, gridColReturnApply).ToString().Trim() == "1")
                            {
                                sErr2 = sErr2 + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                                continue;
                            }

                            sSQL = "update UFDLImport..OM_MODetails_Import set  ReturnUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnUidDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAuditCount = isnull(ReturnAuditCount,0) + 1,ReturnApply = 1,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "' " +
                                   "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);
                        }
                        if (radioApply.Checked)
                        {
                            sSQL = "update UFDLImport..OM_MODetails_Import set ReturnUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnUidDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAuditCount = isnull(ReturnAuditCount,0) + 1,ReturnApply = 1,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "' " +
                               "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";

                            aList.Add(sSQL);
                        }

                        //sSQL = "insert into _Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                        //aListMail.Add(sSQL);
                    }
                }

                string s = "";
                if (sErr != string.Empty)
                {
                    //MessageBox.Show("���¶�������δ��˲����ٴ�ȷ������\n" + sErr );
                    s = "���¶�������δ��˲����ٴ�ȷ������\n" + sErr;
                }
                if (sErr2 != string.Empty)
                {
                    s = s + "\n���¶��������Ѿ�������ȷ�ϲ����ٴ�����\n" + sErr2;
                }
                if (sErr1 != string.Empty)
                {
                    s = s + "\n���¶�������δ�����ǩ����2\n" + sErr1;
                }
                if (s != "")
                {
                    MessageBox.Show(s);
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("�ٴ�ȷ������ɹ���");


                    //////////
                    //SendMail(aListMail, 3);

                    GetGridView();
                }
                else
                {
                    MessageBox.Show("û�е�����Ҫ�ٴ�ȷ�ϣ�");
                }

            }
            catch (Exception ee)
            {
                throw new Exception("�ٴ�ȷ������ʧ�ܣ�  " + ee.Message);
            }
        }

        private void btnUnAudit()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                string sErr2 = "";
                bool b = true;

                //ArrayList aListMail = new ArrayList();
                //aListMail.Add("delete _Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");


                if (radioApply.Checked)
                {
                    DialogResult d = MessageBox.Show("�Ƿ�д���ǩ����2��\n �ǣ���ǩ����2���񣺻�ǩ���ڣ�ȡ�����˳���������", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.Yes)
                    {
                        b = true;
                    }
                    if (d == DialogResult.No)
                    {
                        b = false;
                    }
                    if (d == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        if (gridView2.GetRowCellValue(i, gridColReturnAudit).ToString().Trim() == string.Empty)
                        {
                            sErr2 = sErr2 + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                            continue;
                        }

                        if (radioApply.Checked)
                        {
                            if (b)
                            {
                                sSQL = "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',bAgain=1,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                       "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                                aList.Add(sSQL);

                                sSQL = "update @u8.OM_MODetails set cDefine37 = null where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sSQL = "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',bAgain=0,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                         "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                                aList.Add(sSQL);

                                sSQL = "update @u8.OM_MODetails set cDefine36 = null,cDefine37 = null where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                        }
                        if (!radioApply.Checked)
                        {
                            sSQL = "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                         "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);


                            if (b)
                            {
                                sSQL = "update @u8.OM_MODetails set cDefine37 = null where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sSQL = "update @u8.OM_MODetails set cDefine36 = null,cDefine37 = null where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                        }
                        //sSQL = "insert into _Table_TempTH(a1,a2,a3,a4,a5)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                        //aListMail.Add(sSQL);
                    }
                }

                if ((sErr + sErr2) != string.Empty)
                {
                    if (sErr != string.Empty)
                    {
                        FrmMsgBox fBox = new FrmMsgBox();
                        string s = "";
                        if (sErr != "")
                        {
                            s = s + "���¶�������δ��˲�������\n" + sErr + "\n\n";
                        }
                        if (sErr2 != "")
                        {
                            s = s + sErr2;
                        }
                        fBox.richTextBox1.Text = s;
                        fBox.ShowDialog();
                    }
                }


                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("����ɹ���");

                    //SendMail(aListMail, 2);
                    GetGridView();
                }
                else
                {
                    MessageBox.Show("��ѡ����Ҫ��������ݣ�");
                }

            }
            catch (Exception ee)
            {
                throw new Exception("����ʧ�ܣ�  " + ee.Message);
            }
        }

        private void btnAudit()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                string sErr2 = "";

                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete _Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");

                bool bUnLockTomatoUser = false;

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    //������Ҫ�������ݣ�������������
                    if (Convert.ToInt32(gridView2.GetRowCellValue(i, gridColbTomato)) == 1 && gridView2.GetRowCellValue(i, gridColUnLockTomatoUser).ToString().Trim() == "")
                    {
                        bUnLockTomatoUser = true;
                    }

                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        if (Convert.ToInt32(gridView2.GetRowCellValue(i, gridColbTomato)) == 1 && gridView2.GetRowCellValue(i, gridColUnLockTomatoUser).ToString().Trim() == "")
                        {
                            sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��Ҫ���ܽ���\n";
                            continue;
                        }

                        /*
                          * ��ǩ���⣺
                          * 1.��ǩ���ڵ������ǩ�Ķ�������<=��������5%�����������ܽ����Ϳ��Խ�����ˣ�
                          * 2.>��������5%�ĵ���ǩ�Ľ����������ƻ�����֮ǰ����Ҳ��������Ϳ�����ˣ�
                          * 3.����ɹ������ϲ�����ѯ����������ƻ�ʱ��ģ����������˹�������
                          * 4.�ɹ�/ί�ⶩ���Ļ�ǩ���ڱ�����ͬ��������һ������֮ǰ��
                          */

                        if (gridView2.GetRowCellValue(i, gridColbLock).ToString().ToLower().Trim() == "y")
                        {
                            bool b = false;

                            double dQty = 0;        //��������
                            try
                            {
                                dQty = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQuantity));
                            }
                            catch { }
                            double dQtyUn = 0;        //δ��������
                            try
                            {
                                dQtyUn = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQtyUnIn));
                            }
                            catch { }

                            DateTime dColReturnDate2 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2));

                            sSQL = "SELECT �������� FROM DolleDatabase..OmPlanProduction WHERE (�Ƿ��� = 'Y') and �Ӽ����� = '" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "' and ���۶����� = '" + gridView2.GetRowCellValue(i, gridColcItemCode).ToString().Trim() + "'";
                            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                            if (dQty * 0.05 < dQtyUn)
                            {
                                b = true;
                            }
                            else
                            {
                                if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows.Count > 1)
                                {
                                    b = true;
                                }
                                if (dtTemp.Rows.Count == 1)
                                {
                                    DateTime dWorkPlan = Convert.ToDateTime(dtTemp.Rows[0]["��������"]);
                                    if (dWorkPlan > dColReturnDate2)
                                    {
                                        b = true;
                                    }
                                }
                            }
                            if (b)
                            {
                                sErr2 = sErr2 + "�� " + (i + 1) + " �Ѿ�����������������ϵ������" + "\n";
                                continue;
                            }
                        }

                        if (radioApply.Checked)    //���λ�ǩ
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����2δ��д����ȷ\n";
                                continue;
                            }

                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����2�������ڵ�¼����\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..OM_MODetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',returndate2='" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bAgain = 1 " +
                                   "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);

                            gridView2.SetRowCellValue(i, gridColbAgain, "��");

                            sSQL = "update @u8.OM_MODetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);

                            aList.Add(sSQL);
                        }
                        else                      //һ�λ�ǩ
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ����δ��д����ȷ\n";
                                continue;
                            }

                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "�� " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", ��ǩ���ڲ������ڵ�¼����\n";
                                continue;
                            }
                            sSQL = "update UFDLImport..OM_MODetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                   "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);

                            string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();
                            if (iR == "��")
                            {
                                sSQL = "update @u8.OM_MODetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                            }
                            else
                            {
                                sSQL = "update @u8.OM_MODetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                            }
                            aList.Add(sSQL);
                        }
                        sSQL = "insert into _Table_TempTH(a1,a2,a3,a4,a5)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                        aListMail.Add(sSQL);
                    }

                }

                //if (bUnLockTomatoUser)
                //{ 
                //    //�����ʼ��������ܽ�����
                //    FrmMailListSend frmMail = new FrmMailListSend();
                //    DataRow drMail = frmMail.dt.NewRow();
                //    drMail["Subject"] = "ί�ⶩ��������������";
                //    drMail["sText"] = "";
                //    drMail["bUsed"] = "-1";
                //    drMail["mailAddress"] = "wl@dolle.com.cn";
                //    drMail["mailPerID"] = "wl@dolle.com.cn";
                //    drMail["mailPer"] = "����";
                //    drMail["sMailCC"] = "dolle_sz@126.com";

                //    frmMail.dt.Rows.Add(drMail);

                //    try
                //    {
                //        frmMail.sDO = "����Ҫ������ί�ⶩ������ע��鿴";
                //        frmMail.FrmMailListSend_Load(null, null);
                //        frmMail.btnOK_Click(null, null);
                //    }
                //    catch { }
                //}

                if ((sErr + sErr2) != string.Empty)
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    string s = "";
                    if (sErr != "")
                    {
                        s = s + "���¶�������δȷ�ϲ�������\n" + sErr + "\n\n";
                    }
                    if (sErr2 != "")
                    {
                        s = s + sErr2;
                    }
                    fBox.richTextBox1.Text = s;
                    fBox.ShowDialog();
                    return;
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("��˳ɹ���");

                    //////////
                    //SendMail(aListMail, 1);
                    ////////////

                    GetGridView();
                }
                else
                {
                    MessageBox.Show("û����Ҫ��˵����ݣ�");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("���ʧ�ܣ�  " + ee.Message);
            }
        }

        /// <summary>
        /// ȷ��
        /// </summary>
        private void btnSave()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete _Table_TempTH");

                string sSQL = "";
                string sErr = "";

                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {

                        if (gridView2.GetRowCellDisplayText(i, gridColReturnDate2).ToString().Trim() != "")
                        {
                            if (Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColReturnDate2)) != Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColdArriveDate)) && gridView2.GetRowCellDisplayText(i, gridColReturnRemark).ToString().Trim() == "")
                            {
                                sErr = sErr + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " ��ǩ����2��ƻ��������ڲ�һ�£�������дԭ��\n";
                                continue;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColReturnDate1)) != Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColdArriveDate)) && gridView2.GetRowCellDisplayText(i, gridColReturnRemark).ToString().Trim() == "")
                            {
                                sErr = sErr + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " ��ǩ������ƻ��������ڲ�һ�£�������дԭ��\n";
                                continue;
                            }
                        }

                        string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();

                        if (iR != "��")
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "�� " + (i+1) + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " δ�趨��ǩ���ڣ�\n";
                                continue;
                            }
                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)) < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "�� " + (i + 1) + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " ��ǩ���ڲ����ڽ���֮ǰ��\n";
                                continue;
                            }

                            sSQL = "if exists(select * from UFDLImport..OM_MODetails_Import where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')  " +
                                        "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply = null,ReturnDate1 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnDate2 = null  where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                    "else " +
                                        "insert into UFDLImport..OM_MODetails_Import(MODetailsID,accid,ReturnDate1,accyear,ReturnRemark)values " +
                                        "( " + gridView2.GetRowCellValue(i, gridColID) + ",200,'" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "', '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "')";

                            aList.Add(sSQL);

                            string d1 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)).ToString("yyyy-MM-dd").ToLower();
                            string d2 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColdArriveDate)).ToString("yyyy-MM-dd").ToLower();
                            if (d1 == d2)
                            {
                                sSQL = "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                        "where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                sSQL = "update @u8.OM_MODetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where MODetailsID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sSQL = "insert into _Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                                aListMail.Add(sSQL);
                            }
                        }
                        else
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "�� " + (i + 1) + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " δ�趨��ǩ����2��\n";
                                continue;
                            }

                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "�� " + (i + 1) + " ������" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " ���ϣ�" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " ��ǩ���ڲ����ڽ���֮ǰ��\n";
                                continue;
                            }

                            sSQL = "if exists(select * from UFDLImport..OM_MODetails_Import where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "') " +
                                       "update UFDLImport..OM_MODetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply = null,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "'  where MODetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                   "else " +
                                       "insert into UFDLImport..OM_MODetails_Import(MODetailsID,accid,ReturnDate2,accyear,ReturnRemark)values " +
                                       "( " + gridView2.GetRowCellValue(i, gridColID) + ",200,'" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "','" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "')";

                            aList.Add(sSQL);


                            sSQL = "insert into _Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                            aListMail.Add(sSQL);
                        }

                    }
                }
                bool b = true;
                if (sErr.Trim() != "")
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    fBox.richTextBox1.Text = "���ڴ����Ƿ������\n" + sErr;
                    DialogResult d = fBox.ShowDialog();

                    //DialogResult d = MessageBox.Show("���ڴ����Ƿ������\n" + sErr, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d == DialogResult.OK)
                    {
                        b = true;
                    }
                    else
                    {
                        b = false;
                    }
                }

                if (b)
                {
                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("ȷ�ϳɹ���");

                        //SendMail(aListMail, 0);

                        GetGridView();
                    }
                    else
                    {
                        MessageBox.Show("��ѡ����Ҫȷ�ϵ����ݣ�");
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("ȷ��ʧ�ܣ�  " + ee.Message);
            }
        }

        private void GetPOID()
        {
            string sSQL = "select cCode as iID from @u8.OM_MOMain where 1=1 ";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditPOID1.Properties.DataSource = dt;
            lookUpEditPOID2.Properties.DataSource = lookUpEditPOID1.Properties.DataSource;
        }

        private void FrmStockOrderReturn_Load(object sender, EventArgs e)
        {
            try
            {
                GetPOID();

                dateEdit1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                lookUpEditPOID1.Enabled = true;
                lookUpEditPOID2.Enabled = true;
                lookUpEditPOID1.Properties.ReadOnly = false;
                lookUpEditPOID2.Properties.ReadOnly = false;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Properties.ReadOnly = false;

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                //GetVendor();

                txtVenCode.Properties.ReadOnly = false;
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count == 0)
                {
                    txtVenCode.Enabled = true;
                    gridColcVenName.Visible = true;
                    panel1.Visible = true;
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                        gridColcVenName.Visible = true;
                        gridCol���ڼƻ�����.Visible = true;
                        gridCol�����ƻ���������.Visible = true;
                        panel1.Visible = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                        gridColcVenName.Visible = false;
                        gridCol���ڼƻ�����.Visible = false;
                        gridCol�����ƻ���������.Visible = false;
                        panel1.Visible = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                }

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "apply")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }

                gridColReturnDate2.OptionsColumn.AllowEdit = false;
                gridColReturnDate1.OptionsColumn.AllowEdit = true;

                btnSel();

                panel1.Enabled = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�  " + ee.Message);
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

        private void lookUpVendor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radioUnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioUnSure.Checked)
                {
                    GetGridView();

                    panel1.Enabled = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "apply")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }

                    gridColReturnDate1.OptionsColumn.AllowEdit = true;
                    gridColReturnDate2.OptionsColumn.AllowEdit = false;

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radioEnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioEnSure.Checked)
                {
                    GetGridView();

                    panel1.Enabled = true;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "apply")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }

                    gridColReturnDate1.OptionsColumn.AllowEdit = true;
                    gridColReturnDate2.OptionsColumn.AllowEdit = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioAudit.Checked)
                {
                    chkAllRow.Visible = true;

                    GetGridView();

                    panel1.Enabled = false;

                    gridColReturnDate2.OptionsColumn.AllowEdit = true;
                    gridColReturnDate1.OptionsColumn.AllowEdit = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "apply")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }
                }
                else
                {
                    chkAllRow.Visible = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView2.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView2.FocusedRowHandle;

                if (gridView2.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    gridView2.SetFocusedRowCellValue(gridColbChoose, "��");
                }
                else
                {
                    gridView2.SetFocusedRowCellValue(gridColbChoose, "");
                    return;
                }
            }
            catch
            { }
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView2.GetRowCellValue(e.RowHandle, gridView2.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "��")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }



                    DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                    if (e.Column == gridCol�������)
                    {
                        if (Convert.ToBoolean(gridView2.GetRowCellValue(e.RowHandle, gridCol�������)))
                        {
                            DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                        }
                    }
                }
            }
            catch
            { }


            try
            {
                if (e.RowHandle >= 0)
                {
                    if (gridView2.GetRowCellValue(e.RowHandle, gridColiQtyUnIn).ToString().Trim() != "" && Convert.ToInt32(gridView2.GetRowCellValue(e.RowHandle, gridColiQtyUnIn)) != 0)
                    {
                        if (Convert.ToInt32(gridView2.GetRowCellValue(e.RowHandle, gridColbTomato)) == 0)
                        {
                            //e.Appearance.BackColor = null;
                        }
                        if (Convert.ToInt32(gridView2.GetRowCellValue(e.RowHandle, gridColbTomato)) == 2)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                        }
                        if (Convert.ToInt32(gridView2.GetRowCellValue(e.RowHandle, gridColbTomato)) == 1)
                        {
                            e.Appearance.BackColor = Color.Tomato;
                        }
                    }
                }
            }
            catch
            { }
        }

        private void radioApply_CheckedChanged(object sender, EventArgs e)
        {
            if (radioApply.Checked)
            {
                GetGridView();

                panel1.Enabled = true;

                gridColReturnDate2.OptionsColumn.AllowEdit = true;
                gridColReturnDate1.OptionsColumn.AllowEdit = false;

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "apply")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "alteration")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        gridView2.SetRowCellValue(i, gridColbChoose, "��");
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                        gridView2.SetRowCellValue(i, gridColbChoose, "");
                }

            }
            catch
            { }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateEdit1.Enabled = true;
                dateEdit2.Enabled = true;
            }
            else
            {
                dateEdit1.Enabled = false;
                dateEdit2.Enabled = false;
            }
        }

        private void lookUpEditPOID1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditPOID2.EditValue = lookUpEditPOID1.EditValue;
        }

        private void txtDepCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBaseList fList = new FrmBaseList(1);
            if (DialogResult.OK == fList.ShowDialog())
            {
                txtDepCode.Text = fList.sID;
                txtDepName.Text = fList.sText;
            }
        }

        private void txtDepCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "SELECT cDepCode AS iID, cDepName AS iText FROM @u8.Department WHERE bDepEnd =1 and cDepCode = '" + txtDepCode.Text.Trim() + "' ORDER BY cDepCode ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtDepName.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtDepCode.Text = "";
                    txtDepName.Text = "";
                }
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ò�����Ϣʧ�ܣ� " + ee.Message);
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridColReturnDate1 && gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate1).ToString().Trim() != "")
            { 
                
                if(Convert.ToDateTime(gridView2.GetRowCellValue(e.RowHandle,gridColReturnDate1))<DateTime.Today)
                {
                    MessageBox.Show("��ǩ���ڲ������ڽ��죡");
                    gridView2.SetRowCellValue(e.RowHandle, gridColReturnDate1, DBNull.Value);
                }
            }
            if (e.Column == gridColReturnDate2)
            {
                if (Convert.ToDateTime(gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate2)) < DateTime.Today)
                {
                    MessageBox.Show("��ǩ����2�������ڽ��죡");
                    gridView2.SetRowCellValue(e.RowHandle, gridColReturnDate2, DBNull.Value);
                }
            }
        }

        /// <summary>
        /// û�������ƻ���ί���ǩ�������
        /// </summary>
        private void ChecExistkWorkPlan()
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (gridView2.GetRowCellDisplayText(i, gridCol�����ƻ���������).ToString().Trim() == string.Empty)
                {
                    gridView2.SetRowCellValue(i, gridColbTomato, 1);
                }
            }

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                string sItemCode = gridView2.GetRowCellDisplayText(i,gridColcItemCode).ToString().Trim();
                string scInvCode = gridView2.GetRowCellDisplayText(i, gridColcInvCode).ToString().Trim();       //�Ӽ�����
                string sSQL = "select c.InvCode as �Ӽ�����,e.InvCode as ĸ������ from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomID 	inner join @u8.bas_part c on b.ComponentId = c.partid inner join @u8.bom_parent d on a.bomID= d.bomID inner join @u8.bas_part e on d.ParentId = e.partid where c.InvCode = '" + scInvCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                for (int j = 0; j < gridView2.RowCount; j++)
                {
                    if (gridView2.GetRowCellDisplayText(j, gridColbTomato).ToString().Trim() == "1")
                        continue;

                    if (i == j)
                        continue;

                    string sItemCode2 = gridView2.GetRowCellDisplayText(j, gridColcItemCode).ToString().Trim();
                    if(sItemCode != sItemCode2)
                        continue;

                    string scInvCodeM = gridView2.GetRowCellDisplayText(j, gridColcInvCode).ToString().Trim();       //ĸ������
                    bool bBom = false;
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        if (dt.Rows[k]["ĸ������"].ToString().Trim() == scInvCodeM)
                        {
                            bBom = true;
                            break;
                        }
                    }
                    if (bBom)
                    {
                        gridView2.SetRowCellValue(i, gridColbTomato, 0);
                    }

                }
            }
        }

        private void radioȫ��_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("����б�ʧ��" + ee.Message);
            }
        }
    }
}