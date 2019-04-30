using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using FrameBaseFunction;

namespace Purchase
{
    public partial class FrmStockOrderEdit : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrderEdit()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "refresh":
                        btnRefrash();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "alter":
                        btnUnAllAudit();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "open":
                        btnOpen();
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

        private void btnRefrash()
        {
            GetPOID();
            GetItemLookUpEditState();
            MessageBox.Show("刷新数据成功！");
        }

        private void btnClose()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";
                int iCount = 0;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                        continue;

                    if (gridView1.GetRowCellValue(i, gridColcState).ToString().Trim() != "1")
                    {
                        //e.Info.DisplayText
                        MessageBox.Show("第" + (i + 1) + "行不是审核状态，不能关闭！");
                        return;
                    }

                    sSQL = "update @u8.PO_Podetails set cbCloser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName.Trim() + "' where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);

                    iCount += 1;

                    gridView1.SetRowCellValue(i, gridColcState, 2);
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                        continue;
                    if (gridView1.GetRowCellValue(i, gridColcState).ToString().Trim() != "2")
                        continue;

                    bool bCloseCode = true;

                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (i != j && gridView1.GetRowCellValue(i, gridColcPOID).ToString().Trim() == gridView1.GetRowCellValue(j, gridColcPOID).ToString().Trim())
                        {
                            if (gridView1.GetRowCellValue(j, gridColcState).ToString().Trim() != "2")
                            {
                                bCloseCode = false;
                                break;
                            }
                        }
                    }

                    if (bCloseCode)
                    {
                        sSQL = "update @u8.PO_Pomain set iverifystateex=2,cState = 2,cCloser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' where Poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim() + " ";
                        aList.Add(sSQL);
                    }
                }
            

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("关闭采购订单" + iCount + "条成功！");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("请选择需要关闭的采购订单！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("关闭失败！ " + ee.Message);
            }
        }

        private void btnOpen()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                        continue;

                    if (gridView1.GetRowCellValue(i, gridColRowcState).ToString().Trim() != "是")
                    {
                        //e.Info.DisplayText
                        MessageBox.Show("第" + (i + 1) + "行不是关闭状态，不能打开！");
                        return;
                    }

                    sSQL = "update @u8.PO_Pomain set iverifystateex=2,cState = 1,cCloser = null where Poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim() + " ";
                    aList.Add(sSQL);

                    sSQL = "update @u8.PO_Podetails set cbCloser = null where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("打开采购订单" + aList.Count / 2 + "条成功！");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("请选择需要打开的采购订单！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("打开失败！ " + ee.Message);
            }
        }

        private void btnUnAudit()
        {
            int iCou = 0;
            ArrayList aList = new ArrayList();
            string sErr = "";
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(i, gridColcState)) != 1)
                    {
                        sErr = sErr + "第" + (i + 1) + "行不是审核状态，不能弃审！" + "\n";
                        continue;
                    }

                    sSQL = "select isnull(fPoRefuseQuantity,0) as 拒收数量,isnull(fPoRetQuantity,0) as 退货数量	,isnull(iReceivedQTY,0) as 累计到货数量,isnull(iArrQTY,0) as 到货数量  " +
                            "from @u8.PO_Pomain a inner join @u8.PO_Podetails b on a.poid = b.poid " +
                            "where isnull(cLocker,'') = '' and isnull(cVerifier,'') <> '' and isnull(cbCloser,'') = '' and a.poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim();
                    DataTable dtiDel =clsSQLCommond.ExecQuery(sSQL);
                    for (int j = 0; j < dtiDel.Rows.Count; j++)
                    {
                        if (Convert.ToDecimal(dtiDel.Rows[j]["拒收数量"]) != 0 || Convert.ToDecimal(dtiDel.Rows[j]["拒收数量"]) != 0 || Convert.ToDecimal(dtiDel.Rows[j]["退货数量"]) != 0 || Convert.ToDecimal(dtiDel.Rows[j]["到货数量"]) != 0)
                        {
                            MessageBox.Show("第" + (i + 1) + "行已经执行，不能弃审！");
                            return;
                        }
                    }

                    iCou = iCou + 1;

                    bool b = false;
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcPOID).ToString().Trim() == gridView1.GetRowCellValue(j, gridColcPOID).ToString().Trim())
                        {
                            double d = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColbUsed));
                            if (d > 0)
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    if (b)
                    {
                        sErr = sErr + "第" + (i + 1) + "行已使用，不能弃审！";
                        continue;
                    }

                    sSQL = "update @u8.PO_Pomain set iverifystateex = 0,cState=0,cAuditTime = null,cAuditDate=null,cVerifier=null " +
                            "where poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim();
                    aList.Add(sSQL);

                }
            }

            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsg = new FrmMsgBox();
                fMsg.Text = "弃审不符合数据";
                fMsg.richTextBox1.Text = sErr;
                fMsg.ShowDialog();
            }
            else
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审" + iCou + "条数据成功！");
                btnSel();
            }
            if (iCou <= 0)
            {
                MessageBox.Show("没有单据需要弃审！");
            }
        }

        private void btnAudit()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                        continue;

                    if (gridView1.GetRowCellValue(i, gridColcState).ToString().Trim() != "0")
                    {
                        //e.Info.DisplayText
                        MessageBox.Show("第" + (i + 1) + "行不是编辑状态，不能审核！");
                        return;
                    }

                    sSQL = "update @u8.PO_Pomain set iverifystateex=2,cState = 1,cAuditDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',cAuditTime = '" +FrameBaseFunction.ClsBaseDataInfo.sLogDate + " " + DateTime.Now.ToString("HH:mm:ss") + "',cVerifier='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' where Poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim() + " ";
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("审核采购订单" + aList.Count + "条成功！");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("请选择需要审核的采购订单！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("审核失败！ " + ee.Message);
            }
        }
        private void btnUnAllAudit()
        {
            FrmMailListSend frmMail = new FrmMailListSend();
            frmMail.sDO = "以下订单已清审";
            FrmMsgBox fBox = new FrmMsgBox();
            fBox.Text = "清审原因";
            //fBox.ShowDialog();
            string sUnAuditText = fBox.richTextBox1.Text;

            int iCou = 0;
            ArrayList aList = new ArrayList();
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(i, gridColcState)) == 2)
                    {
                        sErr = sErr + "第" + (i + 1) + "行是关闭状态，不能清审！" + "\n";
                        continue;
                    }
                    iCou = iCou + 1;

                    bool b = false;
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcPOID).ToString().Trim() == gridView1.GetRowCellValue(j, gridColcPOID).ToString().Trim())
                        {
                            double d = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColbUsed));
                            if (d > 0)
                            {
                                b = true;
                                break;
                            }
                        }
                    }
                    if (b)
                    {
                        sErr = sErr + "第" + (i + 1) + "行已使用，不能清审！";
                        continue;
                    }

                    string sSQL = "update UFDLImport..PO_Pomain_Import set POID = null where accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and POID = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim();
                    aList.Add(sSQL);

                    sSQL = "update @u8.PO_Pomain set iverifystateex = 0,cState=0,cAuditTime = null,cAuditDate=null,cVerifier=null " +
                            "where poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim();
                    aList.Add(sSQL);

                    sSQL = "select distinct cPOID,AuditUid,u.vchrName,v.sEMail from UFDLImport..PO_Pomain_Import pImp inner join @u8.PO_Pomain p on pImp.poid = p.poid " +
                                "inner join UFDLImport.._vendUid v on v.uid = pImp.AuditUid and v.accid = pImp.accid and v.accyear = pImp.accyear inner join _UserInfo u on u.vchrUid = v.uid " +
                            "where p.poid = " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim() + " and pImp.accid = 200 and pImp.accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                    DataTable dtMail = clsSQLCommond.ExecQuery(sSQL);
                    if (dtMail != null && dtMail.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtMail.Rows.Count; j++)
                        {
                            DataRow dr = frmMail.dt.NewRow();
                            dr["mailAddress"] = dtMail.Rows[j]["sEMail"];
                            dr["mailPerid"] = dtMail.Rows[j]["AuditUid"];
                            dr["mailPer"] = dtMail.Rows[j]["vchrName"];
                            dr["Subject"] = "采购订单供应商确认清审";
                            dr["sText"] = sUnAuditText;
                            dr["cCode"] = dtMail.Rows[j]["cPOID"];
                            frmMail.dt.Rows.Add(dr);
                        }
                    }
                }
            }

            if(sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsg = new FrmMsgBox();
                fMsg.Text = "清审不符合数据";
                fMsg.richTextBox1.Text = sErr;
                fMsg.ShowDialog();
            }
            else
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("清审" + iCou + "条数据成功！");

                try
                {
                    frmMail.ShowDialog();
                }
                catch { }

                btnSel();
            }
            if (iCou <=0)
            {
                MessageBox.Show("没有单据需要清审！");
            }
        }

        private void btnSel()
        {
            try
            {
                int iFocuseRow=0;
                if (gridView1.RowCount > 0)
                    iFocuseRow = gridView1.FocusedRowHandle;

                string sSQL = @"
select '' as bChoose,p.POID,p.cPOID,p.dPODate,p.cVenCode,v.cVenName,p.cDepCode,d.cDepName,p.cMemo,ps.ID
    ,ps.cInvCode,(isnull(ps.iArrQTY,0) + isnull(ps.iReceivedQTY,0)) as bUsed,i.cInvName,i.cInvStd,ps.iQuantity,ps.iQuantity as iQuantity2
    ,ps.iNum,ps.iNum as iNum2 ,ps.dArriveDate,iAppIds,isnull(cState,0) as cState,iPerTaxRate,iTaxPrice,iSum,ps.cDefine33 as Remark
    ,case when isnull(cbCloser,'') = '' then '' else '是' end as RowcState
    ,ps.cItemCode
from @u8.PO_Pomain p inner join @u8.PO_Podetails ps on p.POID = ps.POID 
    left join @u8.Department d on d.cDepCode = p.cDepCode 
    left join @u8.Vendor v on v.cVenCode = p.cVenCode 
    left join @u8.Inventory i on i.cInvCode = ps.cInvCode 
where 1=1 
"; 

                if(lookUpEditPOID1.Text.Trim() != "")
                    sSQL = sSQL + " and p.cPOID >= '" + lookUpEditPOID1.Text.Trim()  + "' ";
                if(lookUpEditPOID2.Text.Trim() != "")
                    sSQL = sSQL + " and p.cPOID <= '" + lookUpEditPOID2.Text.Trim()  + "' ";
                if(checkBox1.Checked)
                {
                    sSQL = sSQL + " and p.dPODate >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and p.dPODate <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
                }

                if(txtDepName.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cDepCode = '" + txtDepCode.Text.Trim() + "' " ;
                }
                if(txtVenName.Text.Trim() != "")
                {
                    sSQL = sSQL + " and p.cVenCode = '" + txtVenCode.Text.Trim() + "' " ;
                }

                sSQL = sSQL + " order by  p.POID,ps.ID ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    gridControl1.DataSource = null;
                }
                else
                {
                    gridControl1.DataSource = dt;
                }

                gridView1.FocusedRowHandle = iFocuseRow;

                gridView1.OptionsCustomization.AllowSort = true;
                gridView1.OptionsCustomization.AllowFilter = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！ " + ee.Message);
            }
        }

        private string GetsCode(string sCode, string sDepCode)
        {
            try
            {
                string sDep = sDepCode.Trim().Substring(0, 1);

                string sSQL = "Select cCode from @u8.VoucherContrapose as a Left Join @u8.Department as b ON a.cSeed=b.cDepCode  " +
                            "WHERE cContent = 'department' AND cDepCode = '" + sDep.Trim() + "' " +
                            "order by a.cSeed";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return sCode.Trim().Substring(0, 4) + dt.Rows[0]["cCode"].ToString().Trim() + sCode.Trim().Substring(sCode.Trim().Length-4,4);
                }
                else
                {
                    throw new Exception("获得单据号失败！");
                }
            }
            catch
            {
                throw new Exception("获得单据号失败！");
            }
        }



        private void btnSave()
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "";

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                        continue;

                    if (gridView1.GetRowCellValue(i, gridColcDepName).ToString().Trim() == string.Empty)
                    {
                        //e.Info.DisplayText
                        MessageBox.Show("第" + (i + 1) + "行部门为空，不能保存！");
                        return;
                    }
                    if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == string.Empty)
                    {
                        MessageBox.Show("第" + (i + 1) + "行供应商为空，不能保存！");
                        return;
                    }
                    if (Convert.ToInt32( gridView1.GetRowCellValue(i, gridColcState)) != 0)
                    {
                        MessageBox.Show("第" + (i + 1) + "行不是编辑状态，不能保存！");
                        return;
                    }
                    decimal d1 = base.SetNum(gridView1.GetRowCellValue(i, gridColiQuantity),6);
                    decimal d2 = 0;
                    decimal d3 = base.SetNum(gridView1.GetRowCellValue(i, gridColiQuantity2),6);
                    decimal d4 = 0;
                    decimal d5 = d3 - d1;
                    decimal d6 = 0;
                    if (gridView1.GetRowCellValue(i, gridColiNum) != null && gridView1.GetRowCellValue(i, gridColiNum).ToString().Trim() != string.Empty && Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiNum)) != 0)
                    {
                        d2 = base.SetNum(gridView1.GetRowCellValue(i, gridColiNum),6);
                        d4 = base.SetNum(gridView1.GetRowCellValue(i, gridColiNum2),6);
                        d6 = d4 - d2;
                    }

                    if (d1 <= 0)
                    {
                        MessageBox.Show("行" + (i + 1) + "订单数量必须大于0！");
                        return;
                    }

                    sSQL = "update @u8.PO_Pomain set cDepCode = '" + gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim() + "', cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "',cPOID = '" + GetsCode(gridView1.GetRowCellValue(i, gridColcPOID).ToString().Trim(), gridView1.GetRowCellValue(i, gridColcDepCode).ToString().Trim()) + "',cMemo = '" + gridView1.GetRowCellValue(i, gridColcMemo).ToString().Trim() + "' " +
                            "where poid =  " + gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim();
                    aList.Add(sSQL);


                    if (d2 == 0)
                    {
                        sSQL = "update @u8.PO_Podetails set dArriveDate = '" + gridView1.GetRowCellValue(i, gridColdArriveDate) + "',iQuantity = " + d1 + ",cDefine33 = '" + gridView1.GetRowCellValue(i, gridColRemark2).ToString().Trim() + "' where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    }
                    else
                    {
                        sSQL = "update @u8.PO_Podetails set dArriveDate = '" + gridView1.GetRowCellValue(i, gridColdArriveDate) + "',iQuantity = " + d1 + " , iNum = " + d2 + ",cDefine33 = '" + gridView1.GetRowCellValue(i, gridColRemark2).ToString().Trim() + "' where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    }
                    aList.Add(sSQL);

                    //原币含税单价  6位
                    //无税单价      6位
                    //数量          6位
                    //价税合计      2位   原币含税单价 * 数量
                    //无税金额      2位   价税合计 / （1 + 税率） 
                    //税额          2位   价税合计 - 无税金额 
                    //----------------------------------------------------------------------------------------------------------------
                    //税率
                    decimal ipertaxrate =base.SetNum(gridView1.GetRowCellValue(i,gridColiPerTaxRate),2);
                    //原币含税单价
                    decimal iTaxPrice =base.SetNum(gridView1.GetRowCellValue(i,gridColiTaxPrice),6);
                    //单价(不含税)
                    decimal iUnitCost = iTaxPrice / (1 + ipertaxrate/100);
                    iUnitCost = decimal.Round(iUnitCost, 6);
                    //金额(不含税)
                    decimal iPrice = iUnitCost * base.SetNum(gridView1.GetRowCellValue(i, gridColiQuantity), 6);
                    iPrice = decimal.Round(iPrice, 2);
                    //原币价税合计
                    decimal iOriSum = base.SetNum(gridView1.GetRowCellValue(i, gridColiSum), 2);
                    //原币无税金额 
                    decimal iOriMoney = decimal.Round(iOriSum / (1 + ipertaxrate / 100), 2);
                    //原币税额 
                    decimal iOriTaxPrice = iOriSum - iOriMoney;
                    sSQL = "update @u8.PO_Podetails set iUnitPrice = " + iUnitCost + " ,iMoney = " + iPrice + ",iTax = " + iOriTaxPrice + ",iSum = " + iOriSum + ", " +
                                "iNatUnitPrice = " + iUnitCost + ",iNatMoney = " + iPrice + ",iNatTax = " + iOriTaxPrice + ",iNatSum = " + iOriSum + "," +
                                "iPerTaxRate = " + ipertaxrate + ",iTaxPrice = " + iTaxPrice + " " +
                           " where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
          
                    aList.Add(sSQL);

                    if (gridView1.GetRowCellValue(i, gridColiAppIds).ToString().Trim() != string.Empty)
                    {
                        sSQL = "select * from UFDLImport..PU_AppVouchs_Import where PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                        {
                            if (d5 < 0)
                            {
                                for (int j = 0; j < dtTemp.Rows.Count; j++)
                                {
                                    if (d5 < 0)
                                    {
                                        sSQL = "select fQuantity,fNum,iReceivedQTY,iReceivedNum,fQuantity - iReceivedQTY as iQty,fNum-iReceivedNum as iNum from @u8.PU_AppVouchs  where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                        DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);

                                        if (dtTemp2 == null || dtTemp2.Rows.Count == 0)
                                            continue;

                                        decimal d7 = base.SetNum(dtTemp2.Rows[0]["iQty"],6);
                                        decimal d8 = 0;
                                        if (dtTemp2.Rows[0]["iNum"].ToString().Trim() != "")
                                        {
                                            d8 = base.SetNum(dtTemp2.Rows[0]["iNum"],6);
                                        }
                                        if (j != dtTemp.Rows.Count - 1)
                                        {
                                            if (-d5 > d7)
                                            {
                                                if (d2 == 0)
                                                {
                                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY + " + d7 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                                    aList.Add(sSQL);

                                                    sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty + " + d7 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                                    aList.Add(sSQL);
                                                }
                                                else
                                                {
                                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY + " + d7 + ",iReceivedNum = iReceivedNum + " + d8 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                                    aList.Add(sSQL);

                                                    sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty + " + d7 + ",iNum = iNum + " + d8 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                                    aList.Add(sSQL);
                                                }
                                                d5 = d5 + d7;
                                                d6 = d6 + d8;
                                            }
                                        }
                                        else
                                        {
                                            if (d2 == 0)
                                            {
                                                sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                                aList.Add(sSQL);

                                                sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d5 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                                aList.Add(sSQL);
                                            }
                                            else
                                            {
                                                sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + ",iReceivedNum = iReceivedNum - " + d6 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                                aList.Add(sSQL);

                                                sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d5 + ",iNum = iNum - " + d6 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                                aList.Add(sSQL);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int j = dtTemp.Rows.Count - 1; j >= 0; j--)
                                {
                                    decimal d7 = base.SetNum (dtTemp.Rows[j]["iQty"],6);
                                    decimal d8 = 0;
                                    if (dtTemp.Rows[j]["iNum"].ToString().Trim() != string.Empty)
                                    {
                                        d8 = base.SetNum(dtTemp.Rows[j]["iNum"],6);
                                    }
                                    if (d7 >= d5)
                                    {
                                        if (d2 == 0)
                                        {
                                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                            aList.Add(sSQL);

                                            sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d5 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                            aList.Add(sSQL);
                                        }
                                        else
                                        {
                                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + ",iReceivedNum = iReceivedNum - " + d6 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                            aList.Add(sSQL);

                                            sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d5 + ",iNum = iNum - " + d6 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                            aList.Add(sSQL);
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (d2 == 0)
                                        {
                                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d7 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                            aList.Add(sSQL);

                                            sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d7 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                            aList.Add(sSQL);
                                        }
                                        else
                                        {
                                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d7 + ",iReceivedNum = iReceivedNum - " + d8 + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                                            aList.Add(sSQL);

                                            sSQL = "update UFDLImport..PU_AppVouchs_Import set iQty = iQty - " + d7 + ",iNum = iNum - " + d8 + " where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                                            aList.Add(sSQL);
                                        }
                                        d5 = d5 - d7;
                                        d6 = d6 - d8;
                                    }
                                }
                            }
                        }
                        else
                        {
                            string sID = gridView1.GetRowCellValue(i, gridColiAppIds).ToString().Trim();
                            if (sID != string.Empty)
                            {
                                if (d2 == 0)
                                {
                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + " where AutoID = " + sID;
                                }
                                else
                                {
                                    sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d5 + ",iReceivedNum = iReceivedNum - " + d6 + " where AutoID = " + sID;
                                }
                                aList.Add(sSQL);
                            }
                        }
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存采购订单成功！");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("请选择需要保存的采购订单！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存采购订单失败！ " + ee.Message);
            }
        }

        private void btnDel()
        {
            if (MessageBox.Show("确定删除选中的数据么？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK)
            {
                return;
            }

            string sSQL = "";
            string sPODetailID = "";
            ArrayList aList = new ArrayList();
            ArrayList aPOID = new ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                    continue;

                if (Convert.ToInt32(gridView1.GetRowCellValue(i, gridColcState)) != 0)
                {
                    MessageBox.Show("第" + (i + 1) + "行不是编辑状态，不能删除！");
                    return;
                }

                double d1 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiQuantity));
                double d2 = 0;
                if (gridView1.GetRowCellValue(i, gridColiNum) != null && gridView1.GetRowCellValue(i, gridColiNum).ToString().Trim() != string.Empty && Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiNum)) != 0)
                {
                    d2 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiNum));
                }

                sSQL = "select count(0) from @u8.PO_Pomain a inner join @u8.PO_Podetails b on a.poid = b.poid " +
                        "where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + " and isnull(cLocker,'') = '' and isnull(cVerifier,'') = '' and isnull(cbCloser,'') = ''  ";

                int iDel =Convert.ToInt32( clsSQLCommond.ExecGetScalar(sSQL));
                if (iDel != 0)
                {
                    MessageBox.Show("第" + (i + 1) + "行不是编辑状态，不能删除！");
                    return;
                }

                sSQL = "delete @u8.PO_Podetails where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                aList.Add(sSQL);
                aPOID.Add(gridView1.GetRowCellValue(i, gridColPOID).ToString().Trim());
                if (sPODetailID == string.Empty)
                {
                    sPODetailID = gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                }
                else
                {
                    sPODetailID =sPODetailID + "," + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                }

                sSQL = "select * from UFDLImport..PU_AppVouchs_Import where PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() +" and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        if (d2 == 0)
                        {
                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + dtTemp.Rows[j]["iQty"] + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                        }
                        else
                        {
                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + dtTemp.Rows[j]["iQty"] + ",iReceivedNum = iReceivedNum - " + dtTemp.Rows[j]["iNum"] + " where AutoID = " + dtTemp.Rows[j]["PU_AppVouchID"];
                        }
                        aList.Add(sSQL);

                        sSQL = "delete UFDLImport..PU_AppVouchs_Import where PU_AppVouchID = " + dtTemp.Rows[j]["PU_AppVouchID"] + " and PO_PodetailsID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() +" and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "  ";
                        aList.Add(sSQL);
                    }
                }
                else
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiAppIds).ToString().Trim();
                    if (sID != string.Empty)
                    {
                        if (d2 == 0)
                        {
                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d1 + " where AutoID = " + sID;
                        }
                        else
                        {
                            sSQL = "update @u8.PU_AppVouchs set iReceivedQTY = iReceivedQTY - " + d1 + ",iReceivedNum = iReceivedNum - " + d2 + " where AutoID = " + sID;
                        }
                        aList.Add(sSQL);
                    }
                }
            }

            for (int i = 0; i < aPOID.Count; i++)
            {
                sSQL = "select * from  @u8.PO_Podetails  where poid = " + aPOID[i].ToString().Trim() + " and id not in (" + sPODetailID + ")";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                { }
                else
                {
                    sSQL = "delete @u8.PO_Pomain  where poid = " + aPOID[i].ToString().Trim();
                    aList.Add(sSQL);
                }

            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除采购订单成功！");
                btnSel();
            }
        }

        private void FrmStockOrderEdit_Load(object sender, EventArgs e)
        {
            try
            {
                GetPOID();
                GetItemLookUpEditState();

                dateEdit1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                lookUpEditPOID1.Properties.ReadOnly = false;
                lookUpEditPOID2.Properties.ReadOnly = false;
                dateEdit1.Properties.ReadOnly = false;
                dateEdit2.Properties.ReadOnly = false;

                checkBox1.Checked = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！ " + ee.Message);
            }
        }

        private void GetItemLookUpEditState()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = 0;
            dr["iText"] ="编辑";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 1;
            dr["iText"] = "审核";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 2;
            dr["iText"] = "关闭";
            dt.Rows.Add(dr);

            ItemLookUpEditState.DataSource = dt;
        }

        private void GetPOID()
        {
            string sSQL = "select cPOID as iID from @u8.PO_Pomain where 1=1 order by poid ";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpEditPOID1.Properties.DataSource = dt;
            lookUpEditPOID2.Properties.DataSource = lookUpEditPOID1.Properties.DataSource;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount < 1)
                return;
            int iRow = 1;
            if (gridView1.RowCount == 1)
                iRow = 0;
            else
                iRow = gridView1.FocusedRowHandle;
            if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridView1.Columns["bChoose"], "√");
            }
            else
            {
                gridView1.SetRowCellValue(iRow, gridView1.Columns["bChoose"], "");
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lookUpEditPOID1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditPOID2.EditValue = lookUpEditPOID1.EditValue;
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
                //DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
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
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得部门信息失败！ " + ee.Message);
            }
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

        private void ItemButtonEditVen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow =0;
            if(gridView1.RowCount >0 && gridView1.FocusedRowHandle>=0)
            {
                iRow = gridView1.FocusedRowHandle;
            }
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColcVenCode, fVen.sVenCode.Trim());
                gridView1.SetRowCellValue(iRow, gridColcVenName, fVen.sVenName.Trim());
            }
        }

        private void ItemButtonEditdep_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0 && gridView1.FocusedRowHandle >= 0)
            {
                iRow = gridView1.FocusedRowHandle;
            }
            FrmBaseList fList = new FrmBaseList(1);
            if (DialogResult.OK == fList.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridColcDepCode, fList.sID.Trim());
                gridView1.SetRowCellValue(iRow, gridColcDepName, fList.sText.Trim());
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                }
            }
            catch
            { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColbChoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, "√");
                }

                if (e.Column == gridColcVenCode)
                {
                    string sPOID = gridView1.GetRowCellDisplayText(e.RowHandle, gridColPOID).ToString().Trim();
                    string sSQL = "select cVenCode,cVenName from @u8.vendor where cVenCode = '" + gridView1.GetRowCellDisplayText(e.RowHandle, gridColcVenCode).ToString().Trim() + "' ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (sPOID == gridView1.GetRowCellDisplayText(i, gridColPOID).ToString().Trim())
                        {
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["cVenCode"].ToString().Trim() != gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim())
                                {
                                    gridView1.SetRowCellValue(i, gridColcVenCode, dt.Rows[0]["cVenCode"]);
                                }
                                gridView1.SetRowCellValue(i, gridColcVenName, dt.Rows[0]["cVenName"]);
                            }
                            else
                            {
                                if (gridView1.GetRowCellDisplayText(i, gridColcVenCode).ToString().Trim() != "")
                                {
                                    gridView1.SetRowCellValue(i, gridColcVenCode, "");
                                }
                                gridView1.SetRowCellValue(i, gridColcVenName, "");
                            }
                        }
                    }
                }
                if (e.Column == gridColcDepCode)
                {
                    string sPOID = gridView1.GetRowCellDisplayText(e.RowHandle, gridColPOID).ToString().Trim();
                    string sSQL = "SELECT cDepCode, cDepName FROM @u8.Department WHERE bDepEnd =1 and cDepCode = '" + gridView1.GetRowCellDisplayText(e.RowHandle, gridColcDepCode).ToString().Trim() + "' ORDER BY cDepCode ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (sPOID == gridView1.GetRowCellDisplayText(i, gridColPOID).ToString().Trim())
                        {
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["cDepCode"].ToString().Trim() != gridView1.GetRowCellDisplayText(i, gridColcDepCode).ToString().Trim())
                                {
                                    gridView1.SetRowCellValue(i, gridColcDepCode, dt.Rows[0]["cDepCode"]);
                                }
                                gridView1.SetRowCellValue(i, gridColcDepName, dt.Rows[0]["cDepName"]);
                            }
                            else
                            {
                                if (gridView1.GetRowCellDisplayText(i, gridColcDepCode).ToString().Trim() != "")
                                {
                                    gridView1.SetRowCellValue(i, gridColcDepCode, "");
                                }
                                gridView1.SetRowCellValue(i, gridColcDepName, "");
                            }
                        }
                    }
                }
                if (e.Column == gridColcMemo)
                {
                    string sPOID = gridView1.GetRowCellDisplayText(e.RowHandle, gridColPOID).ToString().Trim();
       
                    string sMemo = "";
                    if (sMemo == "")
                    {
                        sMemo = gridView1.GetRowCellDisplayText(e.RowHandle, gridColcMemo).ToString().Trim();
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (sPOID == gridView1.GetRowCellDisplayText(i, gridColPOID).ToString().Trim())
                        {
                            if (gridView1.GetRowCellDisplayText(i, gridColcMemo).ToString().Trim() != sMemo)
                            {
                                gridView1.SetRowCellValue(i, gridColcMemo, sMemo);
                            }
                        }
                    }
                }
                if (e.Column == gridColiQuantity && radioQty.Checked)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColiNum2).ToString().Trim() != string.Empty && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum2)) != 0)
                    {
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity2));
                        double d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum2));
                        double d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity));
                        gridView1.SetRowCellValue(e.RowHandle, gridColiNum, d3 * d2 / d1);
                    }
                }
                if (e.Column == gridColiNum && radioNum.Checked)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColiNum2).ToString().Trim() != string.Empty && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum2)) != 0)
                    {
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity2));
                        double d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum2));
                        double d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColiNum));
                        gridView1.SetRowCellValue(e.RowHandle, gridColiQuantity, d3 * d1 / d2);
                    }
                }

                if (e.Column == gridColiQuantity || e.Column == gridColiTaxPrice)
                {
                    decimal d1 = base.SetNum(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity), 6);
                    if (d1 <= 0)
                    {
                        MessageBox.Show("订单数量必须大于0");
                    }
                    decimal d2 = base.SetNum(gridView1.GetRowCellValue(e.RowHandle, gridColiTaxPrice), 6);
                    if (d2 <= 0)
                    {
                        MessageBox.Show("订单单价必须大于0");
                    }
                    decimal d3 = d1 * d2;
                    d3 = base.SetNum(d3, 2);
                    gridView1.SetRowCellValue(e.RowHandle, gridColiSum, d3);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("修改单元格数据失败！   " + ee.Message);
            }
        }

        private void radioQty_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiNum).ToString().Trim() == string.Empty || Convert.ToDouble(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiNum)) == 0)
            {
                gridColiNum.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColiNum.OptionsColumn.AllowEdit = true;
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "√");
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "");
                }
            }
            catch
            { }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
//            GridView dgv = sender as GridView;
//            List<GridColSetting> settings = dgv.Tag as List<GridColSetting>;
//            //List<String> megeKey = (from query in settings
//            //                        where query.IsMergeKey == true
//            //                        select query.ColumnName).ToList();

//            List<String> megeKey =new List<String>();
//DataTable dt=clsSQLCommond.ExecQuery("select ColumnName from settings where  IsMergeKey =1");
//foreach(DataRow row in dt.Rows)
//{
//  megeKey.add(row["ColumnName "].ToString());
//}

//            var mergeCol =settings.SingleOrDefault ( t=>t.ColumnName ==e.Column.FieldName );

//            if (mergeCol == null || !mergeCol.IsMergeContext)
//                return ;

//            var settingItem = mergeCol;

//            string devGridColName = "gridColcPOID";
//            if (dgv.Columns.ColumnByName(devGridColName) != null )
//            {

//                bool isMerge=true ;
//                string value1 = e.CellValue1.ToString();
//                string value2 = e.CellValue2.ToString();
//                if(value1 !=value2)
//                {
//                    return ;
//                }

//                foreach (string keyCol in megeKey)
//                {
//                    if (dgv.GetRowCellValue(e.RowHandle1, keyCol) == null || dgv.GetRowCellValue(e.RowHandle2, keyCol) == null)
//                        continue;
//                    string keyValueOld1 = dgv.GetRowCellValue(e.RowHandle1,  keyCol).ToString();
//                    string keyValueOld2 = dgv.GetRowCellValue(e.RowHandle2,  keyCol).ToString();

//                    if (keyValueOld1 != keyValueOld2)
//                    {
//                        isMerge = false ;
//                        break;
//                    }
//                }
//                if (isMerge)
//                {
//                    e.Merge = true;
//                }
//                else
//                {
//                    e.Merge = false;
//                    e.Handled = true;
//                }
//            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
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