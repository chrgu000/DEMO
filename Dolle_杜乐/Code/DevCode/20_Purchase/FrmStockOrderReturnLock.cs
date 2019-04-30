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
    public partial class FrmStockOrderReturnLock : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrderReturnLock()
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
                    case "lock":
                        btnLock();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "export":
                        btnExport();
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

        private void GetGridView()
        {
            try
            {
               
                string sSQL = @"
select ReturnRemark,(case isnull(bAgain,0) when 1 then '√' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id,
    (case isnull(pI.ReturnDate1,'') when  '' then ps.dArriveDate else pI.ReturnDate1 end) as ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo, 
    (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate 
from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID 
    left join UFDLImport..PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '222222' 
    left join @u8.Inventory I on I.cInvCode = ps.cInvCode  
    left join @u8.Vendor v on v.cVenCode = p.cVenCode 
    left join @u8.Department d on d.cDepCode = p.cDepCode 
where  iverifystateex = 2  
";
    sSQL = sSQL.Replace("222222",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                if (!chkAllRow.Checked)
                {
                    sSQL = sSQL + "  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0)) ";
                }
                if (txtDepName.Text.Trim() != "")
                {
                    sSQL = sSQL + "  and  p.cDepCode = '" + txtDepCode.Text.Trim() + "' ";
                }

                if (txtVenCode.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL + "  and p.cVenCode = '" + txtVenCode.Text.Trim() + "' ";
                }

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
                if (radioUnLock.Checked)
                {
                    sSQL = sSQL + " and isnull(bLock,0) = 0 ";
                }
                if (radioLock.Checked)
                {
                    sSQL = sSQL + " and isnull(bLock,0) = 1 ";
                }

                sSQL = sSQL + " order by p.cVenCode,ps.id ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count == 0)
                {
                    gridControl2.DataSource = null;
                }
                else
                {
                    gridControl2.DataSource = dt;
                }
                chkAll.Checked = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
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

                string sUnlockInfo = "";
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        sSQL = "update UFDLImport..PO_Podetails_Import set bLock = 0,Locker=null,LockDate= null " +
                               "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";

                        aList.Add(sSQL);

                        sUnlockInfo = sUnlockInfo + " ; " + gridView2.GetRowCellValue(i, gridColcPOID).ToString().Trim() + "  " + gridView2.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "  " + gridView2.GetRowCellValue(i, gridColcInvName).ToString().Trim() + "\n";
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("解锁成功！");

                    //////////
                    SendMail(sUnlockInfo);
                    ////////////

                    GetGridView();
                }
                else
                {
                    MessageBox.Show("没有需要解锁的数据！");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("解锁失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 锁定
        /// </summary>
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
                    if (gridView2.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        sSQL = "if exists(select * from UFDLImport..PO_Podetails_Import where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')  " +
                                    "update UFDLImport..PO_Podetails_Import set bLock = 1,Locker='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',LockDate= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                                       "where PO_PodetailsID = " + gridView2.GetRowCellValue(i, gridColID) + " and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' " +
                                " else " +
                                    "  insert into UFDLImport..PO_Podetails_Import(PO_PodetailsID,accid,accyear,bLock,Locker,LockDate)values " +
                                    " ( " + gridView2.GetRowCellValue(i, gridColID) + ",200,'" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "',1,'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "')"; 
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("锁定成功！");
                    GetGridView();
                }
                else
                {
                    MessageBox.Show("没有需要锁定的数据！");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("锁定失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sInfo">邮件内容</param>
        private void SendMail(string sInfo)
        {
            try
            {
                string sSQL = @"
select '' as bChoose,isnull(bVend,9) as bVend,vchrUid,vchrName,uid,cvenCode,cVenName,sEMail,isnull(POAduditGrade,0) as POAduditGrade,d.cDepCode,d.cDepName  
from _UserInfo a left join UFDLImport.._vendUid on vchrUid=uid and accid = 200 and accyear = 222222
    left join @u8.vendor on cVenCode = vendCode 
    left join @u8.Department d on d.cDepCode = a.cDepCode
where a.cDepCode = 4 and isnull(sEMail,'') <> ''
";
                sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                string sMail = "";
                string sName = "";
                if (dt == null || dt.Rows.Count < 1)
                {
                    MessageBox.Show("未设置邮箱，不能放松邮件");
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (sMail.Trim() == "")
                        {
                            sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                            sName = dt.Rows[i]["vchrName"].ToString().Trim();
                        }
                        else
                        {
                            sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                            sName = sName + "、" + dt.Rows[i]["vchrName"].ToString().Trim();
                        }
                    }
                }
                if (sMail != "" && sInfo != "")
                {
                    string sEInfo = "尊敬的" + sName + "：以下采购订单已解锁，请注意：\n" + sInfo;
                    FrmMailSend clsMail = new FrmMailSend(sMail, "采购订单解锁", sEInfo);
                    clsMail.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("发送邮件失败，请另行通知！ " + ee.Message);
            }
        }
    

        private void GetPOID()
        {
            string sSQL = "select cPOID as iID from @u8.PO_Pomain where 1=1 ";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditPOID1.Properties.DataSource = dt;
            lookUpEditPOID2.Properties.DataSource = lookUpEditPOID1.Properties.DataSource;
        }

        private void FrmStockOrderReturnLock_Load(object sender, EventArgs e)
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
                }
                else
                {
                    if (dt.Rows[0]["vendCode"].ToString().Trim() == string.Empty)
                    {
                        txtVenCode.Enabled = true;
                        gridColcVenName.Visible = true;
                    }
                    else
                    {
                        txtVenCode.Enabled = false;
                        gridColcVenName.Visible = false;
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
                }
            }
            catch
            { }
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
                        gridView2.SetRowCellValue(i, gridColbChoose, "√");
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

        private void radioUnLock_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }

        private void radioLock_CheckedChanged(object sender, EventArgs e)
        {
            GetGridView();
        }
    }
}