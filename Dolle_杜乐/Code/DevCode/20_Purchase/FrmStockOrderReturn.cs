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
    public partial class FrmStockOrderReturn : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrderReturn()
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
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 生管确认
        /// </summary>
        private void btnsDAudit()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("已审核单据不能恢复解锁！");
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
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                        {
                            if (gridView2.GetRowCellValue(i, gridCol申请生管确认人).ToString().Trim() == "")
                            {
                                sErr = sErr + "行" + (i + 1) + "没有申请，不用确认\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..PO_Podetails_Import set 生管回复人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',生管回复时间= GETDATE(),生管回复意见 = '" + gridView2.GetRowCellValue(i, gridCol生管回复意见).ToString().Trim() + "',生管拒绝=0 " +
                                   "where PO_PodetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);

                            if (radioApply.Checked)     //二次回签
                            {
                                if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                                {
                                    sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期2未填写或不正确\n";
                                    continue;
                                }

                                if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                {
                                    sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期2不能早于登录日期\n";
                                    continue;
                                }

                                sSQL = "update UFDLImport..PO_Podetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',returndate2='" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bAgain = 1 " +
                                       "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                gridView2.SetRowCellValue(i, gridColbAgain, "√");

                                sSQL = "update @u8.PO_Podetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);

                                aList.Add(sSQL);
                            }
                            else                      //一次回签
                            {
                                if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() != string.Empty)
                                {
                                    if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                    {
                                        sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期2不能早于登录日期\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                                    {
                                        sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期未填写或不正确\n";
                                        continue;
                                    }

                                    if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                    {
                                        sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期不能早于登录日期\n";
                                        continue;
                                    }
                                }
                                sSQL = "update UFDLImport..PO_Podetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                       "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();
                                if (iR == "√")
                                {
                                    sSQL = "update @u8.PO_Podetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                }
                                else
                                {
                                    sSQL = "update @u8.PO_Podetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                }
                                aList.Add(sSQL);
                            }
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        MsgBox("提示", sErr);
                        return;
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("回复成功！");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("解锁失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
        /// <summary>
        /// 生管回复
        /// </summary>
        private void btnsDAudit2()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("已审核单据不能恢复解锁！");
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
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                        {
                            if (gridView2.GetRowCellValue(i, gridCol申请生管确认人).ToString().Trim() == "")
                            {
                                sErr = sErr + "行" + (i + 1) + "没有申请，不用确认\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..PO_Podetails_Import set 生管回复人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',生管回复时间= GETDATE(),生管回复意见 = '" + gridView2.GetRowCellValue(i, gridCol生管回复意见).ToString().Trim() + "',生管拒绝=1 " +
                                   "where PO_PodetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        MsgBox("提示", sErr);
                        return;
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("确认成功！");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("解锁失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 申请生管确认
        /// </summary>
        private void btnsAudit()
        {
            try
            {
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radioAudit.Checked)
                    {
                        MessageBox.Show("已审核单据不能恢复解锁！");
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
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                        {
                            sSQL = "update UFDLImport..PO_Podetails_Import set 申请生管确认人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',申请生管确认时间= GETDATE() " +
                                   "where PO_PodetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);
                        }
                    }

                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("成功提交申请！");

                        GetGridView();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("解锁失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }


        private void btnLock()
        {
            try
            {
                if (radioAudit.Checked)
                {
                    MessageBox.Show("已审核单据不能恢复解锁！");
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
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        sSQL = "update UFDLImport..PO_Podetails_Import set UnLockTomatoUser = null,UnLockTomatoDate= null " +
                               "where PO_PodetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("恢复解锁成功！");

                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("解锁失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnLock()
        {
            try
            {
                if (radioUnSure.Checked)
                {
                    MessageBox.Show("供应商尚未确认，不需要解锁！");
                    return;
                }
                if (radioAudit.Checked)
                {
                    MessageBox.Show("已经审核，不能解锁！");
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

                #region 不允许批量解锁

                int iChoose = 0;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        iChoose += 1;
                    }
                }
                if (iChoose != 1)
                {
                    MessageBox.Show("解锁只能选则一行请重新选择！");
                    chkAll.Checked = false;
                    chkAll_CheckedChanged(null, null);
                    return;
                }
                #endregion

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        sSQL = "update UFDLImport..PO_Podetails_Import set UnLockTomatoUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',UnLockTomatoDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                               "where PO_PodetailsID  = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("解锁成功！");

                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("解锁失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                RepStockOrderReturn2 rep = new RepStockOrderReturn2();

                DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                int iRow = 0;
                double d1 = 0;
                double d2 = 0;
                double d3 = 0;

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i,gridColbChoose).ToString().Trim() == "√")
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
                    MessageBox.Show("请选择需要打印的数据！");
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
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "采购供应商确认列表";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView2.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
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
                    }
                }
                if (sText == "变更")
                {
                    gridColdArriveDate.OptionsColumn.AllowEdit = true;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "保存";
                        }
                    }
                }
                ArrayList aList = new ArrayList();
                string sSQL = "";

                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete UFDLImport.._Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");
                  
                if (sText == "保存")
                {
                    try
                    {
                        gridView2.FocusedRowHandle -= 1;
                        gridView2.FocusedRowHandle += 1;
                    }
                    catch { }

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                        {
                            sSQL = " if exists(select * from UFDLImport..PO_Podetails_Import where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')  " +
                                        "update UFDLImport..PO_Podetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',bAgain=0,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null,ReturnDate1=null,ReturnDate2=null " +
                                         "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                    "else " +
                                        "insert into UFDLImport..PO_Podetails_Import(bAgain,PO_PodetailsID,accid,ReturnDate1,ReturnDate2,accyear,ReturnRemark)values " +
                                        "(0, " + gridView2.GetRowCellValue(i, gridColID) + ",200,null,null,'" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "','" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "')";
                           
                            aList.Add(sSQL);

                            sSQL = "update @u8.PO_Podetails set dArriveDate = '" + gridView2.GetRowCellValue(i, gridColdArriveDate) + "',cDefine36 = null,cDefine37 = null where ID= " + gridView2.GetRowCellValue(i, gridColID);
                            aList.Add(sSQL);


                            sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4,a5)values(N'" + sTempKey + "',N'" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "',N'" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                            aListMail.Add(sSQL);
                        }
                    }
                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("变更成功！");

                        SendMail(aListMail, 4);

                        GetGridView();
                        gridColdArriveDate.OptionsColumn.AllowEdit = false;

                        for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                        {
                            if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
                            {
                                base.toolStripMenuBtn.Items[i].Text = "变更";
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("变更失败！  " + ee.Message);
            }
        }

        private void GetGridView()
        {
            try
            {
                string sSQL = "";
                if (txtVenCode.Enabled == true)
                {
                    gridCol生管回复意见.Visible = true;
                    gridCol生管回复时间.Visible = true;
                    gridCol生管回复日期.Visible = true;
                    gridCol生管回复人.Visible = true;
                    gridCol申请生管确认时间.Visible = true;
                    gridCol申请生管确认日期.Visible = true;
                    gridCol申请生管确认人.Visible = true;

                    gridCol退货日期.Visible = true;
                    gridCol退货数量.Visible = true;

                    if (radioUnSure.Checked)
                    {
                        sSQL = @"
select min(c.计划生产日期) as 计划生产日期,a.销售订单号,g.InvCode as 子件编码
into #a
from XWSystemDB_DL.dbo.生产计划 a inner join XWSystemDB_DL.dbo.生产计划明细 b on a.单据号 = b.表头单据号
    inner join XWSystemDB_DL.dbo.生产日计划 c on b.iID = c.生产计划明细iID
    inner join @u8.bas_part d on d.InvCode = b.物料编码
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
group by a.销售订单号,g.InvCode

select min(c.计划生产日期) as 计划生产日期,a.销售订单号,g.InvCode as 子件编码
into #b
from XWSystemDB_DL.dbo.生产计划 a inner join XWSystemDB_DL.dbo.生产计划明细 b on a.单据号 = b.表头单据号
    inner join XWSystemDB_DL.dbo.生产日计划 c on b.iID = c.生产计划明细iID
    inner join @u8.bas_part d on d.InvCode = b.物料编码
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
where c.排产日期 = (select MAX(排产日期) from XWSystemDB_DL.dbo.生产日计划)
group by a.销售订单号,g.InvCode

select i.iInvWeight 
        ,case when iverifystateex = 2 then '正式' else '评审' end as 单据状态
        ,ReturnRemark,(case isnull(bAgain,0) when 1 then '√' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id,
        (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo, 
        (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
         (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, isnull(ps.iArrQTY,0) + isnull(ps.iReceivedQTY,0) as iQtyIn
       ,(ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,e.计划生产日期 as 初期计划日期,f.计划生产日期 as 生产计划需求日期,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate 
         ,申请生管确认人, 申请生管确认时间, 生管回复人, 生管回复时间, 生管回复意见 
        ,ps.cDefine23 as 下一班组,ps.cdefine24 as 计划员 
        ,isnull(g.标记延期,0) as 标记延期
        ,h.退货日期,h.iQty as 退货数量
from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID 
        left join UFDLImport..PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '222222' left join @u8.Inventory I on I.cInvCode = ps.cInvCode  
        left join @u8.Vendor v on v.cVenCode = p.cVenCode left join @u8.Department d on d.cDepCode = p.cDepCode  
        left join #a e on e.销售订单号 = ps.cItemCode and e.子件编码 = ps.cInvCode 
        left join #b f on f.销售订单号 = ps.cItemCode and f.子件编码 = ps.cInvCode 
        left join 
        (
	        select CAST(case when isnull(SUM(标记延期),0) = 0 then 0 else 1 end as bit) as 标记延期,销售订单号
	        from XWSystemDB_DL.dbo.外销订单总表
	        group by 销售订单号
        )g on g.销售订单号 = ps.citemcode
        left join
        (
            select  a.退货日期,sum(b.iQuantity) as iQty,a.iPOsID,a.cVenCode
            from 
            (
	            select max(a.dDate) as 退货日期,b.iPOsID , b.cInvCode,a.cVenCode
	            from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id
	            where ISNULL(b.iQuantity,0) < 0 
		            and a.cPTCode = '01'
	            group by b.iPOsID  , b.cInvCode,a.cVenCode
            ) a inner join 
            (
	            select a.dDate,a.cVenCode,b.iQuantity,b.iPOsID , b.cInvCode from  @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where a.cPTCode = '01' and ISNULL(b.iQuantity,0) < 0 
            ) b on a.iPOsID = b.iPOsID and a.退货日期 = b.dDate and a.cInvCode = b.cInvCode and a.cVenCode = b.cVenCode
            group by a.退货日期,a.iPOsID,a.cVenCode
        )h on h.iPOsID = ps.id
        
where  isnull(cCloser,'') = '' and isnull(cbCloser,'') = ''  and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) 


";

                        sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                        if (radio评审订单.Checked)
                        {
                            sSQL = sSQL + " and isnull(iverifystateex,0) <> 2  ";
                        }
                        if (radio正式订单.Checked)
                        {
                            sSQL = sSQL + " and iverifystateex = 2  ";
                        }
                    }
                    else
                    {
                        sSQL = @"
select min(c.计划生产日期) as 计划生产日期,a.销售订单号,g.InvCode as 子件编码
into #a
from XWSystemDB_DL.dbo.生产计划 a inner join XWSystemDB_DL.dbo.生产计划明细 b on a.单据号 = b.表头单据号
    inner join XWSystemDB_DL.dbo.生产日计划 c on b.iID = c.生产计划明细iID
    inner join @u8.bas_part d on d.InvCode = b.物料编码
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
group by a.销售订单号,g.InvCode

select min(c.计划生产日期) as 计划生产日期,a.销售订单号,g.InvCode as 子件编码
into #b
from XWSystemDB_DL.dbo.生产计划 a inner join XWSystemDB_DL.dbo.生产计划明细 b on a.单据号 = b.表头单据号
    inner join XWSystemDB_DL.dbo.生产日计划 c on b.iID = c.生产计划明细iID
    inner join @u8.bas_part d on d.InvCode = b.物料编码
    inner join @u8.bom_parent e on e.ParentId = d.PartId
    inner join @u8.bom_opcomponent f on f.BomId = e.BomId
    inner join @u8.bas_part g on g.PartId = f.ComponentId
where c.排产日期 = (select MAX(排产日期) from XWSystemDB_DL.dbo.生产日计划)
group by a.销售订单号,g.InvCode

select case when iverifystateex = 2 then '正式' else '评审' end as 单据状态,ReturnRemark,(case isnull(bAgain,0) when 1 then '√' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id,
        pI.ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo,  
        (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
        (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn,isnull(ps.iArrQTY,0) + isnull(ps.iReceivedQTY,0) as iQtyIn
        ,(ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,e.计划生产日期 as 初期计划日期,f.计划生产日期 as 生产计划需求日期,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate 
        ,申请生管确认人, 申请生管确认时间, 生管回复人, 生管回复时间, 生管回复意见 
        ,ps.cDefine23 as 下一班组,ps.cdefine24 as 计划员 
        ,isnull(g.标记延期,0) as 标记延期
        ,h.退货日期,h.iQty as 退货数量
from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID 
        left join UFDLImport..PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '222222' 
        left join @u8.Inventory I on I.cInvCode = ps.cInvCode   
        left join @u8.Vendor v on v.cVenCode = p.cVenCode 
        left join @u8.Department d on d.cDepCode = p.cDepCode 
        left join #a e on e.销售订单号 = ps.cItemCode and e.子件编码 = ps.cInvCode 
        left join #b f on f.销售订单号 = ps.cItemCode and f.子件编码 = ps.cInvCode 
        left join 
        (
	        select CAST(case when isnull(SUM(标记延期),0) = 0 then 0 else 1 end as bit) as 标记延期,销售订单号
	        from XWSystemDB_DL.dbo.外销订单总表
	        group by 销售订单号
        )g on g.销售订单号 = ps.citemcode
        left join
        (
            select  a.退货日期,sum(b.iQuantity) as iQty,a.iPOsID,a.cVenCode
            from 
            (
	            select max(a.dDate) as 退货日期,b.iPOsID , b.cInvCode,a.cVenCode
	            from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id
	            where ISNULL(b.iQuantity,0) < 0 
		            and a.cPTCode = '01'
	            group by b.iPOsID  , b.cInvCode,a.cVenCode
            ) a inner join 
            (
	            select a.dDate,a.cVenCode,b.iQuantity,b.iPOsID , b.cInvCode from  @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id where a.cPTCode = '01' and ISNULL(b.iQuantity,0) < 0 
            ) b on a.iPOsID = b.iPOsID and a.退货日期 = b.dDate and a.cInvCode = b.cInvCode and a.cVenCode = b.cVenCode
            group by a.退货日期,a.iPOsID,a.cVenCode
        )h on h.iPOsID = ps.id
where  1=1 
";
                        sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                        if (radio评审订单.Checked)
                        {
                            sSQL = sSQL + " and isnull(iverifystateex,0) <> 2  ";
                        }
                        if (radio正式订单.Checked)
                        {
                            sSQL = sSQL + " and iverifystateex = 2  ";
                        }

                        if (!chkAllRow.Checked)
                        {
                            sSQL = sSQL + "  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0))  ";
                        }
                    }
                }
                else
                {
                    gridCol生管回复意见.Visible = false;
                    gridCol生管回复时间.Visible = false;
                    gridCol生管回复日期.Visible = false;
                    gridCol生管回复人.Visible = false;
                    gridCol申请生管确认时间.Visible = false;
                    gridCol申请生管确认日期.Visible = false;
                    gridCol申请生管确认人.Visible = false;

                    gridCol退货日期.Visible = false;
                    gridCol退货数量.Visible = false;

                    if (radioUnSure.Checked)
                    {
                        sSQL = @"
select case when iverifystateex = 2 then '正式' else '评审' end as 单据状态,ReturnRemark,(case isnull(bAgain,0) when 1 then '√' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id,
    (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo,
    (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
    ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0) as iQtyUnIn,  isnull(ps.iArrQTY,0) + isnull(ps.iReceivedQTY,0) as iQtyIn
    ,(ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate
    ,申请生管确认人, 申请生管确认时间, 生管回复人, 生管回复时间, 生管回复意见 
    ,ps.cDefine23 as 下一班组,ps.cdefine24 as 计划员 
     ,isnull(g.标记延期,0) as 标记延期
from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID left join UFDLImport..PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '222222' left join @u8.Inventory I on I.cInvCode = ps.cInvCode  left join @u8.Vendor v on v.cVenCode = p.cVenCode left join @u8.Department d on d.cDepCode = p.cDepCode 
    left join 
        (
	        select CAST(case when isnull(SUM(标记延期),0) = 0 then 0 else 1 end as bit) as 标记延期,销售订单号
	        from XWSystemDB_DL.dbo.外销订单总表
	        group by 销售订单号
        )g on g.销售订单号 = ps.citemcode
where  1=1 and isnull(cCloser,'') = '' and isnull(cbCloser,'') = ''  and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) ";

    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));

                        if (radio评审订单.Checked)
                        {
                            sSQL = sSQL + " and isnull(iverifystateex,0) <> 2  ";
                        }
                        if (radio正式订单.Checked)
                        {
                            sSQL = sSQL + " and iverifystateex = 2  ";
                        }
                    }
                    else
                    {
                        sSQL = @"
select case when iverifystateex = 2 then '正式' else '评审' end as 单据状态,ReturnRemark,(case isnull(bAgain,0) when 1 then '√' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id,
    pI.ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo,  
    (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, 
    ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0) as iQtyUnIn,  isnull(ps.iArrQTY,0) + isnull(ps.iReceivedQTY,0) as iQtyIn, 
    (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate 
    ,申请生管确认人, 申请生管确认时间, 生管回复人, 生管回复时间, 生管回复意见 
    ,ps.cDefine23 as 下一班组,ps.cdefine24 as 计划员 
    ,isnull(g.标记延期,0) as 标记延期
from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID left join UFDLImport..PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '222222' left join @u8.Inventory I on I.cInvCode = ps.cInvCode   left join @u8.Vendor v on v.cVenCode = p.cVenCode left join @u8.Department d on d.cDepCode = p.cDepCode 
        left join 
        (
	        select CAST(case when isnull(SUM(标记延期),0) = 0 then 0 else 1 end as bit) as 标记延期,销售订单号
	        from XWSystemDB_DL.dbo.外销订单总表
	        group by 销售订单号
        )g on g.销售订单号 = ps.citemcode
where  1=1 ";

                        sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));

                        if (radio评审订单.Checked)
                        {
                            sSQL = sSQL + " and isnull(iverifystateex,0) <> 2  ";
                        }
                        if (radio正式订单.Checked)
                        {
                            sSQL = sSQL + " and iverifystateex = 2  ";
                        }
                        if (!chkAllRow.Checked)
                        {
                            sSQL = sSQL + "  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0))  ";
                        }

                    }
                }
                if (radioEnSure.Checked || radioApply.Checked)
                {
                    if (radio未申请.Checked)
                    {
                        sSQL = sSQL + " and isnull(申请生管确认人,'') = '' and isnull(生管回复人,'') = '' ";
                    }
                    if (radio待回复.Checked)
                    {
                        sSQL = sSQL + " and (isnull(申请生管确认人,'') <> '' and (isnull(生管回复人,'') = '' or isnull(生管拒绝,0) = 1)) ";
                    }
                    if (radio已回复.Checked)
                    {
                        sSQL = sSQL + " and isnull(申请生管确认人,'') <> '' and isnull(生管回复人,'') <> '' ";
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

                if(radioAudit.Checked)
                    sSQL = sSQL + "  and isnull(ReturnApply,0) <> 1 and isnull(ReturnAudit,0) = 1 ";
                if (radioUnSure.Checked)
                    sSQL = sSQL + " and  isnull(ReturnAudit,0) <> 1  and  pI.ReturnDate1 is null ";
            
                if (radioEnSure.Checked)
                    sSQL = sSQL + " and isnull(ReturnAudit,0) <> 1 and  pI.ReturnDate1 is not null and isnull(ReturnApply,0) = 0 ";
                if (radioApply.Checked)
                    sSQL = sSQL + " and isnull(ReturnApply,0) = 1 and isnull(ReturnAudit,0) = 1 ";
                if (lookUpEditPOID1.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cPOID >= '" + lookUpEditPOID1.Text.Trim() + "' ";
                }
                if (lookUpEditPOID2.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cPOID <= '" + lookUpEditPOID2.Text.Trim() + "' ";
                }
                if (checkBox1.Checked)
                {
                    sSQL = sSQL + " and p.dPODate >= '" + dateEdit1.Text.Trim() + "' and p.dPODate <= '" + dateEdit2.Text.Trim() + "' ";
                }


                sSQL = sSQL + " order by p.cVenCode,ps.id ";

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
                        if (gridView2.GetRowCellValue(i, gridColcVenCode).ToString().Trim() == "0623" || gridView2.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "杜乐标贴类打印")
                        {
                            continue;
                        }

                        DateTime d1;
                        if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() != "")
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColReturnDate2).ToString()).ToString("yyyy-MM-dd"));
                        else if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() != "")
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColReturnDate1).ToString()).ToString("yyyy-MM-dd"));
                        else
                            d1 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridColdArriveDate).ToString()).ToString("yyyy-MM-dd"));

                        DateTime d2 = DateTime.Parse("2099-1-1");
                        DateTime d3 = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                        if (gridView2.GetRowCellValue(i, gridCol生产计划需求日期) != null && gridView2.GetRowCellValue(i, gridCol生产计划需求日期).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol生产计划需求日期).ToString()).ToString("yyyy-MM-dd"));
                        else if (gridView2.GetRowCellValue(i, gridCol初期计划日期) != null && gridView2.GetRowCellValue(i, gridCol初期计划日期).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol初期计划日期).ToString()).ToString("yyyy-MM-dd"));

                        if (d1 > d2 || d1 < d3)
                        {
                            gridView2.SetRowCellValue(i, gridColbTomato, 1);
                        }

                        ///有待考证
                        //if (d1 < d3)
                        //{
                        //    gridView2.SetRowCellValue(i, gridColbTomato, 2);
                        //}
                        //if (d1 > d2 || d2 < d3)
                        //{
                        //    gridView2.SetRowCellValue(i, gridColbTomato, 1);
                        //}
                    }
                }   
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 再次确认申请
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
                string sErr3 = "";


                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete UFDLImport.._Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");
                  

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
            
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == "")
                        {
                            sErr1 = sErr1 + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                            continue;
                        }
                        if (gridView2.GetRowCellValue(i, gridCol单据状态).ToString().Trim() == "评审")
                        {
                            sErr3 = sErr3 + "行" + (i + 1).ToString() + "是评审单据不能二次回签，如需改变回签日期请与业务员联系\n";
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

                            sSQL = "update UFDLImport..PO_Podetails_Import set ReturnUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnUidDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAuditCount = isnull(ReturnAuditCount,0) + 1,ReturnApply = 1,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "' " +
                                   "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);
                        }
                        if (radioApply.Checked)
                        {
                            sSQL = "update UFDLImport..PO_Podetails_Import set ReturnUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnUidDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnAuditCount = isnull(ReturnAuditCount,0) + 1,ReturnApply = 1,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "' " +
                               "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";

                            aList.Add(sSQL);
                        }

                        sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                        aListMail.Add(sSQL);
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
                            s = s + "以下订单物料未审核不需再次确认申请\n" + sErr + "\n\n";
                        }
                        if (sErr2 != "")
                        {
                            s = s + sErr2;
                        }
                        fBox.richTextBox1.Text = s;
                        fBox.ShowDialog();
                    }
                }
                if (sErr3.Trim() != "")
                {
                    MsgBox( "提示",sErr3);
                    return;
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("再次确认申请成功！");
                    GetGridView();
                }
                else
                {
                    MessageBox.Show("没有单据需要再次确认！");
                }

            }
            catch (Exception ee)
            {
                throw new Exception("再次确认申请失败！  " + ee.Message);
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

                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete UFDLImport.._Table_TempTH");
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");
                  

                if (radioApply.Checked)
                {
                    DialogResult d = MessageBox.Show("是否写入回签日期2！\n 是：回签日期2；否：回签日期；取消：退出本次弃审", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
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
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (gridView2.GetRowCellValue(i, gridColbLock).ToString().ToLower().Trim() == "y")
                        {
                            sErr2 = sErr2 + "行 " + (i + 1) + "已经锁定，请与生管联系解锁！" + "\n";
                            continue;
                        }
                        if (gridView2.GetRowCellValue(i, gridColReturnAudit).ToString().Trim() == string.Empty)
                        {
                            sErr = sErr + gridView2.GetRowCellValue(i, gridColcPOID) + ":" + gridView2.GetRowCellValue(i, gridColcInvCode) + ";";
                            continue;
                        }

                        if (radioApply.Checked)
                        {
                            if (b)
                            {
                                sSQL = "update UFDLImport..PO_Podetails_Import set bAgain=1,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                       "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                                aList.Add(sSQL);

                                sSQL = "update @u8.PO_Podetails set cDefine37 = null where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sSQL = "update UFDLImport..PO_Podetails_Import set bAgain=0,ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                         "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                                aList.Add(sSQL);

                                sSQL = "update @u8.PO_Podetails set cDefine36 = null,cDefine37 = null where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                        }
                        if (!radioApply.Checked)
                        {
                            sSQL = "update UFDLImport..PO_Podetails_Import set ReturnAudit = 0,ReturnAuditUID = null,ReturnAuditDate= null " +
                                         "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
                            aList.Add(sSQL);


                            if (b)
                            {
                                sSQL = "update @u8.PO_Podetails set cDefine37 = null where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }
                            else
                            {
                                sSQL = "update @u8.PO_Podetails set cDefine36 = null,cDefine37 = null where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);
                            }


                            sSQL = @"
select cInvCode,iQuantity,cItemCode,cDefine36,cDefine37 
from @u8.PO_Podetails 
where ID= {0}
";
                            sSQL = string.Format(sSQL, gridView2.GetRowCellValue(i, gridColID).ToString().Trim());
                            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                            if (dtTemp.Rows[0]["cDefine36"].ToString().Trim() != "" && BaseFunction.ReturnDate(dtTemp.Rows[0]["cDefine36"]) > Convert.ToDateTime("2018-01-01"))
                            {

                            }
                            else
                            {

                                string sInvCode = dtTemp.Rows[0]["cInvCode"].ToString().Trim();
                                decimal dQty = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["iQuantity"]);
                                string scSOCode = dtTemp.Rows[0]["cItemCode"].ToString().Trim();

                                sSQL = @"
select iID,子件编码,回签日期,回签日期2,本次下单数量 
from XWSystemDB_DL..订单评审运算3 a left join @u8.so_somain b on a.销售订单ID = b.id
where 子件编码 = '{0}' and b.cSOCODE = '{1}'
";
                                sSQL = string.Format(sSQL, sInvCode, scSOCode);
                                dtTemp = clsSQLCommond.ExecQuery(sSQL);
                                if (dtTemp != null && dtTemp.Rows.Count == 1)
                                {
                                    if (dtTemp.Rows[0]["子件编码"].ToString().Trim() == sInvCode && BaseFunction.ReturnDecimal(dtTemp.Rows[0]["本次下单数量"]) == dQty)
                                        sSQL = @"
update XWSystemDB_DL..订单评审运算3 set 回签日期2 = null,回签人 = null,回签日期 = null where iID = {0}
";
                                    sSQL = string.Format(sSQL, dtTemp.Rows[0]["iID"].ToString().Trim());
                                    aList.Add(sSQL);
                                }
                            }
                        }
                        sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4,a5)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                        aListMail.Add(sSQL);
                    }
                }

                if ((sErr + sErr2) != string.Empty)
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    string s = "";
                    if (sErr != "")
                    {
                        s = s + "以下订单物料未确认不需弃审\n" + sErr + "\n\n";
                    }
                    if (sErr2 != "")
                    {
                        s = s + sErr2;
                    }
                    fBox.richTextBox1.Text = s;
                    fBox.ShowDialog();
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("弃审成功！");

                    SendMail(aListMail, 2);
                    GetGridView();
                }
                else
                {
                    MessageBox.Show("请选择需要弃审的数据！");
                }

            }
            catch (Exception ee)
            {
                throw new Exception("弃审失败！  " + ee.Message);
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

                ArrayList aListMail = new ArrayList();
                aListMail.Add("delete UFDLImport.._Table_TempTH"); 
                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");

                bool bUnLockTomatoUser = false;

                for (int i = 0; i < gridView2.RowCount; i++)
                { 
                    //存在需要解锁数据，提醒生产解锁
                    if (Convert.ToInt32(gridView2.GetRowCellValue(i, gridColbTomato)) == 1 && gridView2.GetRowCellValue(i, gridColUnLockTomatoUser).ToString().Trim() == "")
                    {
                        bUnLockTomatoUser = true;
                    }
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (Convert.ToInt32(gridView2.GetRowCellValue(i, gridColbTomato)) == 1 && gridView2.GetRowCellValue(i, gridColUnLockTomatoUser).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 需要生管解锁\n";
                            continue;
                        }

                        /*
                         * 回签问题：
                         * 1.回签日期的如果回签的订单数量<=订单数量5%，则无需生管解锁就可以进行审核；
                         * 2.>订单数量5%的但回签的交期在生产计划日期之前的则也无需解锁就可以审核；
                         * 3.如因采购订单合并，查询出多个生产计划时间的，则由生管人工解锁；
                         * 4.采购/委外订单的回签日期必须在同种物料下一批交期之前。
                         */

                        if (gridView2.GetRowCellValue(i, gridColbLock).ToString().ToLower().Trim() == "y")
                        {
                            bool b = false;

                            double dQty = 0;        //订单数量
                            try
                            {
                                dQty = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQuantity));
                            }
                            catch { }
                            double dQtyUn = 0;        //未到货数量
                            try
                            {
                                dQtyUn = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColiQtyUnIn));
                            }
                            catch { }

                            DateTime dColReturnDate2 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2));
                            
                            sSQL = "SELECT 开工日期 FROM DolleDatabase..OmPlanProduction WHERE (是否开启 = 'Y') and 子件编码 = '" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "' and 销售订单号 = '" + gridView2.GetRowCellValue(i, gridColcItemCode).ToString().Trim() + "'";
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
                                    DateTime dWorkPlan = Convert.ToDateTime(dtTemp.Rows[0]["开工日期"]);
                                    if (dWorkPlan > dColReturnDate2)
                                    {
                                        b = true;
                                    }
                                }
                            }
                            if (b)
                            {
                                sErr = sErr + "行 " + (i + 1) + " 已经锁定，请与生管联系解锁！" + "\n";
                                continue;
                            }
                        }

                        if (radioApply.Checked)     //二次回签
                        {

                            if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期2未填写或不正确\n";
                                continue;
                            }

                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期2不能早于登录日期\n";
                                continue;
                            }

                            sSQL = "update UFDLImport..PO_Podetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',returndate2='" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bAgain = 1 " +
                                   "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);

                            gridView2.SetRowCellValue(i, gridColbAgain, "√");

                            sSQL = "update @u8.PO_Podetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);

                            aList.Add(sSQL);
                        }
                        else                      //一次回签
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期未填写或不正确\n";
                                continue;
                            }

                            if (Convert.ToDateTime( gridView2.GetRowCellValue(i, gridColReturnDate1)) < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + "行 " + (i + 1) + " " + gridView2.GetRowCellValue(i, gridColcPOID) + "," + gridView2.GetRowCellValue(i, gridColcInvCode) + ", 回签日期不能早于登录日期\n";
                                continue;
                            }
                            sSQL = "update UFDLImport..PO_Podetails_Import set returndate1='" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "',ReturnApply=0,ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                   "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                            aList.Add(sSQL);

                            string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();
                            if (iR == "√")
                            {
                                sSQL = "update @u8.PO_Podetails set cDefine36 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "',cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);
                            }
                            else
                            {
                                sSQL = "update @u8.PO_Podetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);
                            }
                            aList.Add(sSQL);
                        }
                        sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4,a5)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenCode).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcVenName).ToString() + "')";
                        aListMail.Add(sSQL);
                    }

                }

                if (bUnLockTomatoUser)
                {
                    //发送邮件提醒生管解锁。
                    FrmMailListSend frmMail = new FrmMailListSend();
                    DataRow drMail = frmMail.dt.NewRow();
                    drMail["Subject"] = "委外订单订单解锁需求";
                    drMail["sText"] = "";
                    drMail["bUsed"] = "-1";
                    drMail["mailAddress"] = "wl@dolle.com.cn";
                    drMail["mailPerID"] = "wl@dolle.com.cn";
                    drMail["mailPer"] = "温玲";
                    drMail["sMailCC"] = "dolle_sz@126.com";

                    frmMail.dt.Rows.Add(drMail);

                    try
                    {
                        //frmMail.sDO = "有需要解锁的委外订单，请注意查看";
                        //frmMail.FrmMailListSend_Load(null, null);
                        //frmMail.btnOK_Click(null, null);
                    }
                    catch { }
                }

                if ((sErr) != string.Empty)
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    string s = "";
                    if (sErr != "")
                    {
                        s = s  + "以下订单物料存在错误，不能审核\n" + sErr + "\n\n";
                    }
                    fBox.richTextBox1.Text = s;
                    fBox.ShowDialog();

                    return;
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("审核成功！");

                    //////////
                    SendMail(aListMail,1);
                    ////////////

                    GetGridView();
                }
                else
                {
                    MessageBox.Show("没有需要审核的数据！");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("审核失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="aListMail">发送内容</param>
        /// <param name="p">0 保存，1 审核</param>
        private void SendMail(ArrayList aListMail, int p)
        {
            try
            {
                string sType = "";
                if (p == 0)
                {
                    sType = "确认";
                }
                if (p == 1)
                {
                    sType = "审核";
                }
                if (p == 2)
                {
                    sType = "弃审";
                }
                if (p == 3)
                {
                    sType = "二次确认";
                }
                if (p == 4)
                {
                    sType = "变更";
                }
                string sSQL = "";
                clsSQLCommond.ExecSqlTran(aListMail);
                sSQL = "select distinct a4,a5 from UFDLImport.._Table_TempTH";
                DataTable dtEmail = clsSQLCommond.ExecQuery(sSQL);

                if (dtEmail != null && dtEmail.Rows.Count > 0)
                {
                    FrmMailListSend frmMail = new FrmMailListSend();

                    for (int i = 0; i < dtEmail.Rows.Count; i++)
                    {
                        if (p == 0 || p == 3 )
                        {
                            sSQL = "select t.*,v.sEMail from UFDLImport.._Table_TempTH t inner join _UserInfo u on t.a4 = u.vchrName inner join UFDLImport.._vendUid v on v.uid = u.vchrUid and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " where a4 = '" + dtEmail.Rows[i]["a4"].ToString().Trim() + "'";
                        }
                        if (p == 1 || p == 2 || p == 4)
                        {
                            sSQL = "select * from UFDLImport.._Table_TempTH t inner join UFDLImport.._vendUid u on t.a4 = u.vendCode  and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " where a4 = '" + dtEmail.Rows[i]["a4"].ToString().Trim() + "'";
                        }
                        DataTable dtMail = clsSQLCommond.ExecQuery(sSQL);

                        string sCode = "";
                        for (int j = 0; j < dtMail.Rows.Count; j++)
                        {
                            if (dtMail.Rows[j]["sEMail"].ToString().Trim() != "")
                            {
                                if (sCode == "")
                                {
                                    sCode = "采购订单：" + dtMail.Rows[j]["a2"].ToString().Trim() + ",物料：" + dtMail.Rows[j]["a3"].ToString().Trim();
                                }
                                else
                                {
                                    sCode = sCode + "；采购订单：" + dtMail.Rows[j]["a2"].ToString().Trim() + ",物料：" + dtMail.Rows[j]["a3"].ToString().Trim();
                                }
                            }
                        }

                        if (sCode != string.Empty)
                        {
                            string sName = dtEmail.Rows[i]["a4"].ToString().Trim();
                            if (dtEmail.Rows[i]["a5"].ToString().Trim() != "")
                            {
                                sName = dtEmail.Rows[i]["a5"].ToString().Trim();
                            }
                            
                            string sSub = "采购订单已经确认";
                            if (p == 4)
                            {
                                sSub = "采购订单确认通知";
                            }
                            else
                            {
                                sCode = sCode + "  已经" + sType + "！";
                            }
                            string sText =  "尊敬的" + sName + " ，您好 " + sCode + "，谢谢！" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "  " + DateTime.Now.ToString("yyyy-MM-dd");
                            if (p == 4)
                            {
                                sText = "尊敬的" + sName + " ，您好 请尽快回签您的采购订单  " + sCode + "，谢谢！" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "  " + DateTime.Now.ToString("yyyy-MM-dd");
                            }

                            if (dtMail == null || dtMail.Rows.Count < 1 || dtMail.Rows[i]["sEMail"].ToString().Trim() == "")
                            {
                                MessageBox.Show("请设定邮件地址！");
                            }
                            else
                            {
                                DataRow drMail = frmMail.dt.NewRow();
                                drMail["Subject"] = sSub;
                                drMail["sText"] = sText;
                                drMail["bUsed"] = "-1";
                                drMail["mailAddress"] = dtMail.Rows[i]["sEMail"].ToString().Trim();

                                frmMail.dt.Rows.Add(drMail);

                                //clsMail = new FrmMail(dtMail.Rows[i]["sEMail"].ToString().Trim(), sSub, sText);
                                //clsMail.ShowDialog();
                            }
                        }
                    }

                    if (frmMail.dt.Rows != null && frmMail.dt.Rows.Count > 0)
                    {
                        frmMail.FrmMailListSend_Load(null, null);
                        frmMail.btnOK_Click(null, null);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("发送邮件失败，请另行通知！ " + ee.Message);
            }
        }
       

        /// <summary>
        /// 确认
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
                aListMail.Add("delete UFDLImport.._Table_TempTH");

                string sSQL = "";
                string sErr = "";

                string sTempKey = FrameBaseFunction.ClsBaseDataInfo.sUid + " " + FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("hh:mm:ss");

                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (gridView2.GetRowCellDisplayText(i, gridColReturnDate2).ToString().Trim() != "")
                        {
                            if (Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColReturnDate2)) != Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColdArriveDate)) && gridView2.GetRowCellDisplayText(i, gridColReturnRemark).ToString().Trim() == "")
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 回签日期2与计划到货日期不一致，必须填写原因！\n";
                                continue;
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColReturnDate1)) != Convert.ToDateTime(gridView2.GetRowCellDisplayText(i, gridColdArriveDate)) && gridView2.GetRowCellDisplayText(i, gridColReturnRemark).ToString().Trim() == "")
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 回签日期与计划到货日期不一致，必须填写原因！\n";
                                continue;
                            }
                        }

                        string iR = gridView2.GetRowCellValue(i, gridColbAgain).ToString().Trim();

                        if (iR != "√")
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 未设定回签日期！\n";
                                continue;
                            }
                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)) < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 回签日期不能在今天之前！\n";
                                continue;
                            }

                            sSQL = "if exists(select * from UFDLImport..PO_Podetails_Import where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')  " +
                                        "update UFDLImport..PO_Podetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "', ReturnApply = null,ReturnDate1 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "',ReturnDate2 = null  where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                    "else " +
                                        "insert into UFDLImport..PO_Podetails_Import(PO_PodetailsID,accid,ReturnDate1,accyear,ReturnRemark)values " +
                                        "( " + gridView2.GetRowCellValue(i, gridColID) + ",200,'" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "','" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "')";
                           
                            aList.Add(sSQL);

                            string d1 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate1)).ToString("yyyy-MM-dd").ToLower();
                            string d2 = Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColdArriveDate)).ToString("yyyy-MM-dd").ToLower();
                            if (d1 == d2)
                            {
                                sSQL = "update UFDLImport..PO_Podetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "', ReturnAudit = 1,ReturnAuditUID = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ReturnAuditDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                        "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                                aList.Add(sSQL);

                                sSQL = "update @u8.PO_Podetails set cDefine37 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1) + "' where ID= " + gridView2.GetRowCellValue(i, gridColID);
                                aList.Add(sSQL);

                                sSQL = @"
select cInvCode,iQuantity,cItemCode,* 
from @u8.PO_Podetails 
where ID= {0}
";
                                sSQL = string.Format(sSQL, gridView2.GetRowCellValue(i, gridColID).ToString().Trim());
                                DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                                //for (int ii = 0; ii < dtTemp.Rows.Count; ii++)
                                //{
                                string sInvCode = dtTemp.Rows[0]["cInvCode"].ToString().Trim();
                                decimal dQty = BaseFunction.ReturnDecimal(dtTemp.Rows[0]["iQuantity"]);
                                string scSOCode = dtTemp.Rows[0]["cItemCode"].ToString().Trim();

                                sSQL = @"
select iID,子件编码,回签日期,回签日期2,本次下单数量 
from XWSystemDB_DL..订单评审运算3 a left join @u8.so_somain b on a.销售订单ID = b.id
where 子件编码 = '{0}' and b.cSOCODE = '{1}'
";
                                sSQL = string.Format(sSQL, sInvCode, scSOCode);
                                dtTemp = clsSQLCommond.ExecQuery(sSQL);
                                if (dtTemp != null && dtTemp.Rows.Count == 1)
                                {
                                    if (dtTemp.Rows[0]["子件编码"].ToString().Trim() == sInvCode && BaseFunction.ReturnDecimal(dtTemp.Rows[0]["本次下单数量"]) == dQty)
                                        sSQL = @"
update XWSystemDB_DL..订单评审运算3 set 回签日期2 = '{0}',回签人 = '{1}',回签日期 =getdate() where iID = {2}
";
                                    sSQL = string.Format(sSQL, BaseFunction.ReturnDate(gridView2.GetRowCellValue(i, gridColReturnDate1)).ToString("yyyy-MM-dd"), sUserName, dtTemp.Rows[0]["iID"].ToString().Trim());
                                    aList.Add(sSQL);
                                }
                                //}
                            }
                            else
                            {
                                sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                                aListMail.Add(sSQL);
                            }

                            //    sSQL = "update XWSystemDB_DL..订单评审运算3 set 回签日期2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate1).ToString().Trim() + "',回签人 = '" + gridView评审.GetRowCellValue(i, gridCol回签人1).ToString().Trim() + "',回签日期 = '" + gridView评审.GetRowCellValue(i, gridCol回签日期1).ToString().Trim() + "' where iID = " + gridView评审.GetRowCellValue(i, gridColiID1).ToString().Trim();
                            //  aList.Add(sSQL);
                        }
                        else
                        {
                            if (gridView2.GetRowCellValue(i, gridColReturnDate2).ToString().Trim() == string.Empty)
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 未设定回签日期2！\n";
                                continue;
                            }

                            if (Convert.ToDateTime(gridView2.GetRowCellValue(i, gridColReturnDate2)) < DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                            {
                                sErr = sErr + " 订单：" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + " 物料：" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + " 回签日期不能在今天之前！\n";
                                continue;
                            }

                            sSQL = "if exists(select * from UFDLImport..PO_Podetails_Import where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "') " +
                                       "update UFDLImport..PO_Podetails_Import set ReturnRemark = '" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "', ReturnApply = null,ReturnDate2 = '" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "'  where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                   "else " +
                                       "insert into UFDLImport..PO_Podetails_Import(PO_PodetailsID,accid,ReturnDate2,accyear,ReturnRemark)values " +
                                       "( " + gridView2.GetRowCellValue(i, gridColID) + ",200,'" + gridView2.GetRowCellValue(i, gridColReturnDate2) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "','" + gridView2.GetRowCellValue(i, gridColReturnRemark).ToString().Trim() + "')";

                            aList.Add(sSQL);

                            sSQL = "insert into UFDLImport.._Table_TempTH(a1,a2,a3,a4)values('" + sTempKey + "','" + gridView2.GetRowCellValue(i, gridColcPOID).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcInvCode).ToString() + "--" + gridView2.GetRowCellValue(i, gridColcInvName).ToString() + "','" + gridView2.GetRowCellValue(i, gridColcMaker).ToString() + "')";
                            aListMail.Add(sSQL);
                        }
                    }
                }
                bool b = true;
                if (sErr.Trim() != "")
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    fBox.richTextBox1.Text = "存在错误，是否继续：\n" + sErr;
                    DialogResult d  = fBox.ShowDialog();

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
                        MessageBox.Show("确认成功！");

                        SendMail(aListMail, 0);

                        GetGridView();
                    }
                    else
                    {
                        MessageBox.Show("请选择需要确认的数据！");
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("确认失败！  " + ee.Message);
            }
        }

        private void GetPOID()
        {
            string sSQL = "select cPOID as iID from @u8.PO_Pomain where 1=1 ";
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
                        gridCol初期计划日期.Visible = true;
                        gridCol生产计划需求日期.Visible = true;
                        panel1.Visible = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                        gridColcVenName.Visible = false;
                        gridCol初期计划日期.Visible = false;
                        gridCol生产计划需求日期.Visible = false;
                        panel1.Visible = false;
                    }
                    txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                    txtVenCode_Leave(null, null);
                 }

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "addrow")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "import")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "add")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "delrow")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
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
                MessageBox.Show("加载窗体失败！  " + ee.Message);
            }
        }

        private DataTable  GetVendor(string sVenCode)
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
                    panel2.Visible = true;

                    GetGridView();

                    panel1.Enabled = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "addrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "import")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "add")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "delrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }

                    gridColReturnDate1.OptionsColumn.AllowEdit = true;
                    gridColReturnDate2.OptionsColumn.AllowEdit = false;

                }
                //else
                //{
                //    panel2.Visible = false;
                //}
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
                    panel1.Enabled = true;
                    panel2.Visible = true;

                    GetGridView();


                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "addrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "import")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "add")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "delrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
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

                    panel1.Enabled = false;
                    panel2.Visible = true;

                    GetGridView();

                    gridColReturnDate2.OptionsColumn.AllowEdit = true;
                    gridColReturnDate1.OptionsColumn.AllowEdit = false;

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "addrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "import")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "add")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "delrow")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
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
                    gridView2.SetFocusedRowCellValue(gridColbChoose, "√");
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
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }



                    DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);
                    if (e.Column == gridCol标记延期)
                    {
                        if (Convert.ToBoolean(gridView2.GetRowCellValue(e.RowHandle, gridCol标记延期)))
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
                panel2.Visible = true;

                gridColReturnDate2.OptionsColumn.AllowEdit = true;
                gridColReturnDate1.OptionsColumn.AllowEdit = false;

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "addrow")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "import")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "add")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "delrow")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "edit")
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
                        gridView2.SetRowCellValue(i, gridColbChoose, "√");
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
                MessageBox.Show("获得部门信息失败！ " + ee.Message);
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridColReturnDate1 && gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate1).ToString().Trim() != "")
            {

                if (Convert.ToDateTime(gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate1)) < DateTime.Today)
                {
                    MessageBox.Show("回签日期不能早于今天！");
                    gridView2.SetRowCellValue(e.RowHandle, gridColReturnDate1, DBNull.Value);
                }
            }
            if (e.Column == gridColReturnDate2&& gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate2).ToString().Trim() != "")
            {
                if (Convert.ToDateTime(gridView2.GetRowCellValue(e.RowHandle, gridColReturnDate2)) < DateTime.Today)
                {
                    MessageBox.Show("回签日期2不能早于今天！");
                    gridView2.SetRowCellValue(e.RowHandle, gridColReturnDate2, DBNull.Value);
                }
            }
        }

        private void radio未申请_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败" + ee.Message);
            }
        }

        private void radio评审订单_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetGridView();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败" + ee.Message);
            }
        }
    }
}