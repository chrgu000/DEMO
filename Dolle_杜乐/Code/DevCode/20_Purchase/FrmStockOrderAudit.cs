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
    public partial class FrmStockOrderAudit : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmStockOrderAudit()
        {
            InitializeComponent();
        }

        private void FrmStockOrderAudit_Load(object sender, EventArgs e)
        {
            try
            {
                lookUpEditCreate.Enabled = true;
                lookUpEditCreate.Properties.ReadOnly = false;
                getlookUpEditCreate();

                gridColAuditState.Visible = false;
                dateEdit1.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                SetConEnable(true);

                GetUidAuditGrade();

                GetItemInfo();
                GetCode();

                string sVend = GetUidVend();
                if (sVend == "all")
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    txtVenCode.Enabled = false;
                    txtVenCode.Text = sVend;
                    gridColcVenCode.Visible = false;
                    gridColcVenName.Visible = false;
                    txtVenCode_Leave(null, null);
                }

                btnGet();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sendmail")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }


                if (lAuditGrade.Text.Trim() == "0")
                {
                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "提交";
                            radioAudit.Text = "已提交";
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "撤销";
                            radioUnAudit.Text = "未提交";
                        }
                    }
                } 
                if (lAuditGrade.Text.Trim() == "2")
                {
                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "审核";
                          
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Text = "弃审";
                         
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
            }
        }

        private void getlookUpEditCreate()
        {
            try
            {
                string sSQL = "select distinct cMaker as iID from @u8.PO_Pomain where isnull(cState,0) = 0 order by cMaker ";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditCreate.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得制单人信息失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得当前帐号对应供应商
        /// </summary>
        /// <returns></returns>
        private string GetUidVend()
        {
            try
            {
                string s = "all";

                if (FrameBaseFunction.ClsBaseDataInfo.sUid.ToLower() == "admin")
                {
                    return s;
                }

                string sSQL = "select * from UFDLImport.._vendUid where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'  and accid =200 and accyear=" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    s = dt.Rows[0]["vendCode"].ToString().Trim();
                }

                if (s == string.Empty)
                {
                    s = "all";
                }

                return s;
            }
            catch (Exception ee)
            {
                throw new Exception("获得帐号供应商信息失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得用户审核权限等级
        /// </summary>
        private void GetUidAuditGrade()
        {
            string sSQL = "select isnull(POAduditGrade,0) from UFDLImport.._vendUid where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' and accid = '200'";
            lAuditGrade.Text = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnGet();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "close":
                        btnUnAllAudit();
                        break;
                    //case "sendmail":
                    //    btnSendMail();
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

        /// <summary>
        /// 发送邮件
        /// </summary>
        private void btnSendMail(string sAdd, string sSub, string sText)
        {
            try
            {
                if (radioAudit.Checked)
                {
                    try
                    {
                        ClseMail clseMail = new ClseMail();
                        clseMail.MailSend(sAdd, sSub, sText);
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("发送邮件失败", "提示");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("邮件发送失败！ " + ee.Message);
            }
        }

        private void btnUnAllAudit()
        {
            if (!radioAllAudit.Checked)
            {
                MessageBox.Show("请选择审核状态列表进行弃审！");
                return;
            }

            string sMsg = "";
            string sSQL = "";
            ArrayList aList = new ArrayList();

            DataTable dtMailToVen = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtMailToVen.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "采购订单号";
            dtMailToVen.Columns.Add(dc);


            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√" && gridView1.GetRowCellValue(i, gridView1.Columns["bUsed"]).ToString().Trim() != "1")
                {
                    sSQL = "update UFDLImport..PO_Pomain_Import set POID = null where accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and POID = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim();
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                sMsg = "清审成功！";
                MessageBox.Show(sMsg);
                btnGet();
            }
            else
            {
                MessageBox.Show("没有单据需要清审！");
            }
        }

        private void btnGet()
        {
            try
            {
                if (radioUnAudit.Checked)
                {
                    GetGrid1();
                }
                if(radioAudit.Checked)
                {
                    GetGrid2();
                }
                if (radioAllAudit.Checked)
                {
                    GetGrid3();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnUnAudit()
        {

            if (!radioAudit.Checked)
            {
                MessageBox.Show("请选择已审核列表进行弃审！");
                return;
            }


            string sMsg = "";
            string sMailToUnAudit = "";
            string sSQL = "";
            ArrayList aList = new ArrayList();

            DataTable dtMailToVen = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtMailToVen.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "采购订单号";
            dtMailToVen.Columns.Add(dc);
            DataRow dr;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√" && gridView1.GetRowCellValue(i, gridView1.Columns["bUsed"]).ToString().Trim() != "1")
                {
                    sSQL = "update UFDLImport..PO_Pomain_Import set POID = null where accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and POID = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim() + " and  AuditState = " + lAuditGrade.Text.Trim();
                    aList.Add(sSQL);

                    //发送邮件给上道审核人员
                    sMailToUnAudit = sMailToUnAudit + gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim() + ";";
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["AuditU8Grade"]).ToString().Trim() == lAuditGrade.Text.Trim())
                    {
                        sSQL = "update @u8.PO_Pomain set cState = 0,cVerifier = null,iverifystateex = 1,cAuditTime=null,cAuditDate=null where POID = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim();
                        aList.Add(sSQL);

                        dr = dtMailToVen.NewRow();
                        dr["供应商"] = gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]).ToString().Trim();
                        dr["采购订单号"] = gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim();
                        dtMailToVen.Rows.Add(dr);
                    }
                    
                    string sPOID = gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim();
                    for (int j = i + 1; j < gridView1.RowCount; j++)
                    {
                        if (sPOID == gridView1.GetRowCellValue(j, gridView1.Columns["cPOID"]).ToString().Trim())
                        {
                            gridView1.SetRowCellValue(j, gridView1.Columns["bUsed"], "1");
                        }
                    }
                }
            }

            if (aList.Count > 0)
            {
                try
                {
                    SendUnMail(sMailToUnAudit, dtMailToVen);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("邮件发送失败，请另行通知！  " + ee.Message);
                }

                clsSQLCommond.ExecSqlTran(aList);
                sMsg = "弃审成功！";
                MessageBox.Show(sMsg);
               
                btnGet();
            }
            else
            {
                MessageBox.Show("没有单据需要弃审！");
            }
        }

        private void SendUnMail(string sMailToUnAudit, DataTable dtMailToVen)
        {
            FrmMsgBox fBox = new FrmMsgBox();
            fBox.Text = "弃审原因";
            fBox.ShowDialog();
            string sErr = "";
            string sUnAuditText = fBox.richTextBox1.Text;

            string sSQL = "";
            
            ArrayList aList = new ArrayList();

            DataTable dtVenMail = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "供应商邮箱";
            dtVenMail.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "采购订单号";
            dtVenMail.Columns.Add(dc);

            if (sMailToUnAudit.Trim() != "")
            {
                string[] sTemp = sMailToUnAudit.Split(';');
                string sTemp2 = "";
                for (int i = 0; i < sTemp.Length; i++)
                {
                    if(sTemp[i].Trim() != "")
                    {
                        if (sTemp2.Trim() == "")
                        {
                            sTemp2 = "'" + sTemp[i].Trim() + "'";
                        }
                        else
                        {
                            sTemp2 =sTemp2 + ",'" + sTemp[i].Trim() + "'";
                        }
                    }
                }

                if (lAuditGrade.Text.Trim() == "1")
                    sSQL = " select distinct u.*,v.* from UFDLImport.._vendUid v inner join _UserInfo u on v.Uid = u.vchrUid inner join  @u8.PO_Pomain p on p.cMaker = u.vchrName where  AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " and cPOID in (" + sTemp2 + ") ";
                else
                    sSQL = "select distinct v.*,u.* from UFDLImport..PO_Pomain_Import p left join _UserInfo u on p.audituid = u.vchrUid inner join UFDLImport.._vendUid v on v.Uid = u.vchrUid and p.accid = v.accid  " +
                            "where p.accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and POAduditGrade = " + lAuditGrade.Text.Trim() + " - 1 and p.accid = 200  and p.poid in(select poid from @u8.PO_Pomain where cPOID in (" + sTemp2 + "))";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                string sMailAddress = "";

                if (dt == null || dt.Rows.Count == 0)
                {
                    sErr = "没有设定后续审核人员，邮件无法发送，请设定，本次请手工发送邮件！";
                }
                else
                {
                    string sName = "";
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        if (dt.Rows[i]["sEMail"] != null && dt.Rows[i]["sEMail"].ToString().Trim() != "")
                        {
                            sMailAddress = sMailAddress + dt.Rows[i]["sEMail"].ToString().Trim() + ";";
                            if (sName.Trim() == "")
                            {
                                sName = "尊敬的" + dt.Rows[i]["vchrName"].ToString().Trim();
                            }
                            else
                            {
                                sName = sName + "、" + dt.Rows[i]["vchrName"].ToString().Trim();
                            }
                        }
                    }
                    sName = sName + "，";
                    string sText = sName + "您好：采购订单：" + sMailToUnAudit + sUnAuditText + " " + FrameBaseFunction.ClsBaseDataInfo.sUserName + " " + DateTime.Now.ToString("yyyy-MM-dd");
                    FrmMailSend clsMail = new FrmMailSend(sMailAddress, "采购订单弃审", sText);
                    clsMail.ShowDialog();
                }
            }
        }

        private void btnAudit()
        {
            string sSQL = "";
            ArrayList aList = new ArrayList();
            string sMailToAudit = "";
            DataTable dtMailToVen = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtMailToVen.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "采购订单号";
            dtMailToVen.Columns.Add(dc);

            DataRow dr;

            DataTable dtMailToCreater = new DataTable();
            DataColumn dcCreater = new DataColumn();
            dcCreater.ColumnName = "制单人";
            dtMailToCreater.Columns.Add(dcCreater);

            dcCreater = new DataColumn();
            dcCreater.ColumnName = "采购订单号";
            dtMailToCreater.Columns.Add(dcCreater);

            DataRow drCreater;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√" && gridView1.GetRowCellValue(i, gridView1.Columns["bUsed"]).ToString().Trim() != "1")
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["AuditU8Grade"]).ToString().Trim() == "")
                    {
                        DialogResult d = MessageBox.Show("单据 " + gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim() + " 物料 " + gridView1.GetRowCellValue(i, gridView1.Columns["cInvCode"]).ToString().Trim() + " " + gridView1.GetRowCellValue(i, gridView1.Columns["cInvName"]).ToString().Trim() + "，未设审核等级，请进行设置！\n是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (d == DialogResult.Yes)
                            continue;
                        else
                            return;
                    }

                    sSQL = " if not exists(select * from UFDLImport..PO_Pomain_Import where accid = 200  and poid = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim() + " and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and AuditState = " + lAuditGrade.Text.Trim() + ") " +
                                "insert into UFDLImport..PO_Pomain_Import(AccID,POID,AuditState,AuditUid,AuditDate,accyear)values " +
                                   "(200,'" + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim() + "'," + lAuditGrade.Text.Trim() + ",'" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)  + "') " +
                           " else update UFDLImport..PO_Pomain_Import set AuditState = " + lAuditGrade.Text.Trim() + ", AuditUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',AuditDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where poid = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim() + " and accid =200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'  and AuditState = " + lAuditGrade.Text.Trim() + " ";
                    aList.Add(sSQL);

                    //审核等级与U8审核等级相同，则发送邮件给供应商及采购员
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["AuditU8Grade"]).ToString().Trim() == lAuditGrade.Text.Trim())
                    {
                        DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColdPODate));
                        DateTime d2 = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                        if (d1 < d2)
                            d1 = d2;
                        sSQL = "update @u8.PO_Pomain set cState = 1,cVerifier = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',iverifystateex = 2,cAuditTime='" + d1.ToString("yyyy-MM-dd") + "',cAuditDate='" + d1.ToString("yyyy-MM-dd") + "' where POID = " + gridView1.GetRowCellValue(i, gridView1.Columns["POID"]).ToString().Trim();
                        aList.Add(sSQL);

                        dr = dtMailToVen.NewRow();
                        dr["供应商"] = gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]).ToString().Trim();
                        dr["采购订单号"] = gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim();
                        dtMailToVen.Rows.Add(dr);
                    }

                    string sPOID = gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim();
                    for (int j = i + 1; j < gridView1.RowCount; j++)
                    {
                        if (sPOID == gridView1.GetRowCellValue(j, gridView1.Columns["cPOID"]).ToString().Trim())
                        {
                            gridView1.SetRowCellValue(j, gridView1.Columns["bUsed"], "1");
                        }
                    }
                }
            }



            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！");
                try
                {
                    SendMail(sMailToAudit, dtMailToVen, dtMailToCreater);
                }
                catch (Exception ee)
                {
                    if (ReturnObjectToInt(lAuditGrade.Text.Trim()) != 2)
                    {
                        MessageBox.Show("邮件发送失败，请另行通知！  " + ee.Message);
                    }
                }
                btnGet();
            }
            else
            {
                throw new Exception("没有单据需要审核！");
            }
        }

        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="sMailToAudit">发给下级审核人员的单据号</param>
        /// <param name="sMailToVen">发给供应商的单据号及供应商编码</param>
        private void SendMail(string sCodeMailToAudit, DataTable dtCodeMailToVen, DataTable dtMailToCreater)
        {
            string sSQL = "";
            
            ArrayList aList = new ArrayList();

            if (dtMailToCreater != null && dtMailToCreater.Rows.Count > 0)
            {
                sSQL = "delete UFDLImport.._MailTemp";
                aList.Add(sSQL);
                for (int i = 0; i < dtMailToCreater.Rows.Count; i++)
                {
                    sSQL = "if exists(select * from UFDLImport.._MailTemp where vencode='" + dtMailToCreater.Rows[i]["制单人"] + "') update UFDLImport.._MailTemp set cCode =cCode + ';" + dtMailToCreater.Rows[i]["采购订单号"] + "' where  vencode='" + dtMailToCreater.Rows[i]["制单人"] + "' " +
                           "else insert into UFDLImport.._MailTemp(venCode,eMail,cCode)values('" + dtMailToCreater.Rows[i]["制单人"] + "',null,'" + dtMailToCreater.Rows[i]["采购订单号"] + "')";
                    aList.Add(sSQL);
                }
                clsSQLCommond.ExecSqlTran(aList);

                sSQL = "select distinct  v.uid,u.vchrName,cCode,sEmail,'' as bUsed  from UFDLImport.._MailTemp m left join UFDLImport.._vendUid v on v.uid=m.venCode and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " left join dbo._UserInfo u on u.vchrUid = uid order by v.uid,cCode,sEmail ";
                DataTable dtT = clsSQLCommond.ExecQuery(sSQL);
                string sUserCode = "";
                string sAddress = "";
                string sCode = "";

                FrmMailListSend frmMail = new FrmMailListSend();
                for (int i = 0; i < dtT.Rows.Count; i++)
                {
                    if (dtT.Rows[i]["bUsed"].ToString().Trim() != "1")
                    {
                        string sUser = dtT.Rows[i]["vchrName"].ToString().Trim();
                        sAddress = dtT.Rows[i]["sEmail"].ToString().Trim();
                        sCode = dtT.Rows[i]["cCode"].ToString().Trim();
                        if (sUserCode == "")
                        {
                            sUserCode = sUser;
                        }
                        else
                        {
                            if (sUser != "")
                            {
                                sUserCode = sUserCode + ";" + sUser;
                            }
                        }
                        for (int j = i + 1; j < dtT.Rows.Count; j++)
                        {
                            if (sUser == dtT.Rows[j]["vchrName"].ToString().Trim())
                            {
                                if (dtT.Rows[j]["sEmail"].ToString().Trim() != "")
                                {
                                    sAddress = sAddress + ";" + dtT.Rows[j]["sEmail"].ToString().Trim();
                                }
                                if (dtT.Rows[j]["cCode"].ToString().Trim() != "")
                                {
                                    sCode = sCode + ";" + dtT.Rows[j]["cCode"].ToString().Trim();
                                }
                                dtT.Rows[j]["bUsed"] = "1";
                            }
                        }
                    }

                    if (sUserCode != "")
                    {
                        string sText = "尊敬的" + sUserCode + " ，您好  采购订单：" + sCode + " 已经审核，谢谢！" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "  " + DateTime.Now.ToString("yyyy-MM-dd");
                        ClseMail clseMail = new ClseMail();
                        clseMail.MailSend(sAddress, "采购订单交期确认", sText);
                    }
                }
            }

            if (dtCodeMailToVen != null && dtCodeMailToVen.Rows.Count > 0)
            {
                sSQL = "delete UFDLImport.._MailTemp";
                aList.Add(sSQL);
                for (int i = 0; i < dtCodeMailToVen.Rows.Count; i++)
                {
                    sSQL = "if exists(select * from UFDLImport.._MailTemp where venCode='" + dtCodeMailToVen.Rows[i]["供应商"] + "') update UFDLImport.._MailTemp set cCode =cCode + ';" + dtCodeMailToVen.Rows[i]["采购订单号"] + "' where  venCode='" + dtCodeMailToVen.Rows[i]["供应商"] + "' " +
                           "else insert into UFDLImport.._MailTemp(venCode,eMail,cCode)values('" + dtCodeMailToVen.Rows[i]["供应商"] + "',null,'" + dtCodeMailToVen.Rows[i]["采购订单号"] + "')";
                    aList.Add(sSQL);
                }
                clsSQLCommond.ExecSqlTran(aList);

                sSQL = "select distinct venCode,v1.cVenName,sEmail,cCode,vchrName,'' as bUsed from UFDLImport.._MailTemp m left join UFDLImport.._vendUid v on v.vendCode=m.venCode and accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " left join dbo._UserInfo u on u.vchrUid = uid left join @u8.vendor v1 on v1.cVenCode = m.venCode order by venCode,cCode,sEmail";
                DataTable dtT = clsSQLCommond.ExecQuery(sSQL);
                string sVenCode = "";

                string sVenMessage = "";
                string sNoAddressMail = "";

                FrmMailListSend frmMail = new FrmMailListSend();
                for (int i = 0; i < dtT.Rows.Count; i++)
                {
                    if (dtT.Rows[i]["bUsed"].ToString().Trim() != "1")
                    {
                        string sVen = dtT.Rows[i]["venCode"].ToString().Trim();
                        string sVenName = dtT.Rows[i]["cVenName"].ToString().Trim();
                        string sAddress = dtT.Rows[i]["sEmail"].ToString().Trim();
                        string sCode = dtT.Rows[i]["cCode"].ToString().Trim();
                        if (sVen.Trim() != "" && sAddress.Trim() == "")
                        {
                            sVenMessage = sVenMessage + sVenName + "\n";
                            sNoAddressMail = sNoAddressMail + sCode + ";";
                            continue;
                        }

                        if (sVenCode == "")
                        {
                            sVenCode = sVen;
                        }
                        else
                        {
                            if (sVen != "")
                            {
                                sVenCode = sVenCode + ";" + sVen;
                            }
                        }
                        for (int j = i + 1; j < dtT.Rows.Count; j++)
                        {
                            if (dtT.Rows[i]["bUsed"].ToString().Trim() == "1")
                            {
                                continue;
                            }
                            if (sVen == dtT.Rows[j]["vchrName"].ToString().Trim())
                            {
                                if (dtT.Rows[j]["cCode"].ToString().Trim() != "")
                                {
                                    sCode = sCode + ";" + dtT.Rows[j]["cCode"].ToString().Trim();
                                }
                                dtT.Rows[j]["bUsed"] = "1";
                            }
                        }
                        if (sVen.Trim() == "" || sAddress.Trim() == "")
                        {
                            continue;
                        }
                        string sText = "尊敬的" + sVenName + " ，您好 请您确认采购订单：" + sCode + " 的交期，谢谢！ " + FrameBaseFunction.ClsBaseDataInfo.sUserName + " " + DateTime.Now.ToString("yyyy-MM-dd");

                        DataRow drMail = frmMail.dt.NewRow();
                        drMail["Subject"] = "采购订单交期确认";
                        drMail["sText"] = sText;
                        drMail["bUsed"] = "-1";
                        drMail["mailAddress"] = sAddress;

                        frmMail.dt.Rows.Add(drMail);
                    }
                }

                if (sVenMessage.Trim() != "")
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    fBox.Text = "";
                    fBox.richTextBox1.Text = "以下厂商未设定邮箱，将人工通知！\n" + sVenMessage;
                    fBox.StartPosition = FormStartPosition.CenterParent;
                    fBox.ShowDialog();

                    string[] sCodeNoMail = sNoAddressMail.Split(';');
                    for (int iCode = 0; iCode < sCodeNoMail.Length; iCode++)
                    {
                        string s = sCodeNoMail[iCode].Trim();
                        if (s.Length > 0)
                        {
                            sSQL = "select cVenName,sEMail,cMaker,vchrUid,cpoid from @u8.PO_Pomain p inner join dbo._UserInfo u on u.vchrName = p.cMaker inner join UFDLImport.._vendUid v on v.uid = u.vchrUid and accid = 200 left join @u8.vendor ve on ve.cVenCode = p.cVenCode where cPOID = '" + s + "' ";
                            DataTable dTempCode = clsSQLCommond.ExecQuery(sSQL);
                            string sAdd = dTempCode.Rows[0]["sEMail"].ToString().Trim();
                            if (sAdd.Trim() != "")
                            {
                                string sText2 = "尊敬的" + dTempCode.Rows[0]["cMaker"].ToString().Trim() + " ，您好 采购订单 " + dTempCode.Rows[0]["cpoid"].ToString().Trim() + " 已经通过审批请手工通知供应商 “" + dTempCode.Rows[0]["cVenName"].ToString().Trim() + "”";

                                DataRow drMail = frmMail.dt.NewRow();
                                drMail["Subject"] = "部分供应商未设定邮件地址";
                                drMail["sText"] = sText2;
                                drMail["bUsed"] = "-1";
                                drMail["mailAddress"] = sAdd;
                            }
                        }
                    }
                }

                if (frmMail.dt.Rows != null && frmMail.dt.Rows.Count > 0)
                {
                    frmMail.FrmMailListSend_Load(null, null);
                    frmMail.btnOK_Click(null, null);
                }
            }

            if (sCodeMailToAudit.Trim() != "")
            {
                sSQL = " select * from UFDLImport.._vendUid v inner join _UserInfo u on v.Uid = u.vchrUid where POAduditGrade = " + lAuditGrade.Text.Trim() + " + 1 and AccID = 200 and AccYear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                string sMailAddress = "";
                string sErr = "";


                FrmMailListSend frmMail = new FrmMailListSend();
                if (dt != null && dt.Rows.Count > 0)
                {
                    sErr = "没有设定后续审核人员，邮件无法发送，请设定，本次请手工发送邮件！";

                    string sName = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["sEMail"] != null && dt.Rows[i]["sEMail"].ToString().Trim() != "")
                        {
                            sMailAddress = sMailAddress + dt.Rows[i]["sEMail"].ToString().Trim() + ";";
                            if (sName.Trim() == "")
                            {
                                sName = "尊敬的" + dt.Rows[i]["vchrName"].ToString().Trim();
                            }
                            else
                            {
                                sName = sName + "、" + dt.Rows[i]["vchrName"].ToString().Trim();
                            }
                        }
                    }
                    sName = sName + "，";
                    string sText = sName + "您好 请您审核采购订单：" + sCodeMailToAudit + "  " + FrameBaseFunction.ClsBaseDataInfo.sUserName + " " + DateTime.Now.ToString("yyyy-MM-dd");
                    //clsMail = new FrmMail(sMailAddress, "采购订单审核", sText);
                    //clsMail.ShowDialog();

                    DataRow drMail = frmMail.dt.NewRow();
                    drMail["Subject"] = "采购订单审核";
                    drMail["sText"] = sText;
                    drMail["bUsed"] = "-1";
                    drMail["mailAddress"] = sMailAddress;
                }

                if (frmMail.dt.Rows != null && frmMail.dt.Rows.Count > 0)
                {
                    frmMail.FrmMailListSend_Load(null, null);
                    frmMail.btnOK_Click(null, null);
                }
            }
        }


        /// <summary>
        /// 待审核列表
        /// </summary>
        private void GetGrid1()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StockOrderAudit]') AND type in (N'U')) DROP TABLE [dbo].[StockOrderAudit]";
            aList.Add(sSQL);
            sSQL = @"
select a.AuditState,a.POID,vchrName 
into StockOrderAudit 
from ( 
        (
            select max(AuditState) as AuditState,POID from UFDLImport..PO_Pomain_Import i where accid = 200 and accyear = 'aaaaaa' group by POID
        )a 
    	left join UFDLImport..PO_Pomain_Import i on i.poid = a.poid and a.AuditState = i.AuditState and i.accyear = 'aaaaaa' and i.accid = '200'
    	left join  dbo._UserInfo u on i.audituid =u.vchrUid 
      )
";
            sSQL = sSQL.Replace("aaaaaa", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            aList.Add(sSQL);

            clsSQLCommond.ExecSqlTran(aList);

            sSQL = @"
select distinct isnull(AuditState,-1) as AuditState,isnull(A.AuditGrade,2) as AuditU8Grade,0 as bUsed,0 as bUsed2,'' as bChoose,isnull(AuditGrade,0) as AuditGrade,p.cVerifier,p.POID, p.cPOID,  
    dPODate,p.cVenCode,v.cVenName,ps.cInvCode,i.cInvName,i.cInvStd,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum, 
    ps.iTaxPrice,ps.dArriveDate,ps.cItemCode,p.cMaker,vchrName  
from @u8.PO_Pomain p left join @u8.PO_Podetails ps on p.POID = ps.POID  
    left join @u8.vendor v on v.cVenCode = p.cVenCode  
    left join @u8.Inventory I on i.cInvCode = ps.cInvCode  
    left join  UFDLImport..AuditGrade A on A.cInvCode = ps.cInvCode and A.accid = '200' 
    left join StockOrderAudit pM on pM.POID = p.POID 
where ps.cbCloser is null and cCloser is null and ((isnull(AuditState,-1) < isnull(A.AuditGrade,2) and isnull(AuditState,-1)+1 = bbbbbb) or ( isnull(AuditState,-1) = isnull(A.AuditGrade,2)  
    and p.iverifystateex <> 2)  and isnull(AuditState,-1) = bbbbbb ) 
";
            sSQL = sSQL.Replace("bbbbbb", lAuditGrade.Text.Trim());

            if (lookUpEditCreate != null && lookUpEditCreate.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cMaker = '" + lookUpEditCreate.Text.Trim() + "' ";
            }
            if (chkDate1.Checked)
            {
                sSQL = sSQL + " and dPODate  >= '" + dateEdit1.DateTime + "' ";
                sSQL = sSQL + " and dPODate  <= '" + dateEdit2.DateTime + "' ";
            }

            if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cVenCode = '" + txtVenCode.Text.ToString().Trim() + "' ";
            }
            if (lookUpCode1.EditValue != null && lookUpCode1.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID >= '" + lookUpCode1.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpCode2.EditValue != null && lookUpCode2.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID <= '" + lookUpCode2.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpItem.EditValue != null && lookUpItem.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and ps.cItemCode = '" + lookUpItem.EditValue.ToString().Trim() + "' ";
            }
            if (txtDepName.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cDepCode = '" + txtDepCode.Text.Trim() + "' ";
            }

            sSQL = sSQL + " and isnull(cVerifier,'') = ''  order by p.POID,ps.cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;

        }

        /// <summary>
        /// 已审核列表
        /// </summary>
        private void GetGrid2()
        {

            int iAuditGrade = int.Parse(lAuditGrade.Text.Trim());
            string sSQL = @"
select distinct isnull(AuditState,-1) as AuditState,isnull(A.AuditGrade,2) as AuditU8Grade,0 as bUsed,0 as bUsed2,'' as bChoose,isnull(AuditGrade,0) as AuditGrade,p.cVerifier,p.POID, p.cPOID, 
     dPODate,p.cVenCode,v.cVenName,ps.cInvCode,i.cInvName,i.cInvStd,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum, 
     ps.iTaxPrice,ps.dArriveDate,ps.cItemCode,p.cMaker,vchrName  
from @u8.PO_Pomain p left join @u8.PO_Podetails ps on p.POID = ps.POID 
     left join @u8.vendor v on v.cVenCode = p.cVenCode  
     left join @u8.Inventory I on i.cInvCode = ps.cInvCode  
     left join  UFDLImport..AuditGrade A on A.cInvCode = ps.cInvCode and A.accid = '200'  
     inner join (select a.AuditState,a.POID,vchrName from (select max(AuditState) as AuditState,POID from UFDLImport..PO_Pomain_Import i where accid = '200' and i.accyear = 'aaaaaa' group by POID ) a
     left join UFDLImport..PO_Pomain_Import i on i.poid = a.poid and a.AuditState = i.AuditState and i.accyear = 'aaaaaa' and i.accid = '200' 
     left join  dbo._UserInfo u on i.audituid =u.vchrUid  ) pM on pM.POID = p.POID 
where ps.cbCloser is null and cCloser is null and isnull(iReceivedQTY,0) = 0  and ((isnull(A.AuditGrade,2) = bbbbbb and p.iverifystateex =2) or (isnull(AuditState,-1) = bbbbbb and isnull(A.AuditGrade,2) > bbbbbb)) 
";
           sSQL = sSQL.Replace("aaaaaa",FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11,4));
           sSQL = sSQL.Replace("bbbbbb",lAuditGrade.Text.Trim());

            if (lookUpEditCreate != null && lookUpEditCreate.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cMaker  = '" + lookUpEditCreate.Text.Trim() + "' ";
            }
            if (chkDate1.Checked)
            {
                sSQL = sSQL + " and dPODate  >= '" + dateEdit1.DateTime + "' ";
                sSQL = sSQL + " and dPODate  <= '" + dateEdit2.DateTime + "' ";
            }
            if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cVenCode = '" + txtVenCode.Text.ToString().Trim() + "' ";
            }
            if (lookUpCode1.EditValue != null && lookUpCode1.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID >= '" + lookUpCode1.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpCode2.EditValue != null && lookUpCode2.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID <= '" + lookUpCode2.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpItem.EditValue != null && lookUpItem.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and ps.cItemCode = '" + lookUpItem.EditValue.ToString().Trim() + "' ";
            }
            if (txtDepName.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cDepCode = '" + txtDepCode.Text.Trim() + "' ";
            }

            sSQL = sSQL + "  order by p.cPOID,ps.cInvCode";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;

        }


        /// <summary>
        /// 获得外销单号
        /// </summary>
        private void GetItemInfo()
        {
            try
            {
                string sSQL = "select citemcode as iID from @u8.fitemss00 order by citemcode ";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpItem.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得外销单号失败：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得采购订单号
        /// </summary>
        private void GetCode()
        {
            string sSQL = "select cPOID as iID from @u8.PO_Pomain where cCloser is null order by cPOID ";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            lookUpCode1.Properties.DataSource = dt;
            lookUpCode2.Properties.DataSource = lookUpCode1.Properties.DataSource ;

        }

        private void lookUpCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpCode2.EditValue = lookUpCode1.EditValue;
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

                if (gridView1.GetRowCellValue(iRow, gridView1.Columns["bChoose"]).ToString().Trim() != "√")
                {
                    string s = gridView1.GetRowCellValue(iRow, gridView1.Columns["cPOID"]).ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (s == gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim())
                        {
                            gridView1.SetRowCellValue(i,gridView1.Columns["bChoose"], "√");
                        }
                    }
                }
                else
                {
                    string s = gridView1.GetRowCellValue(iRow, gridView1.Columns["cPOID"]).ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (s == gridView1.GetRowCellValue(i, gridView1.Columns["cPOID"]).ToString().Trim())
                        {
                            gridView1.SetRowCellValue(i,gridView1.Columns["bChoose"], "");
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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
                    if (s1 == "×")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            {

            }
        }

        private void chkDate1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate1.Checked)
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
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void radioUnAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioUnAudit.Checked)
            {
                GetGrid1();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }
            }
        }

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAudit.Checked)
            {
                GetGrid2();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sendmail")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }
            }
            else
            {

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sendmail")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }
            }
        }

        private void radioAllAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAllAudit.Checked)
            {
                gridColvchrName.Visible = false;
                gridColAuditState.Visible = true;
                GetGrid3();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }
            }
            else
            {
                gridColAuditState.Visible = false;
                gridColvchrName.Visible = true;
            }
        }

        private void GetGrid3()
        {
            int iAuditGrade = int.Parse(lAuditGrade.Text.Trim());

            string sSQL = @"
select isnull(AuditState,-1) as AuditState,isnull(A.AuditGrade,2) as AuditU8Grade,0 as bUsed,0 as bUsed2,'' as bChoose,isnull(AuditGrade,0) as AuditGrade,p.cVerifier,p.POID, p.cPOID,  
    dPODate,p.cVenCode,v.cVenName,ps.cInvCode,i.cInvName,i.cInvStd,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum, 
    ps.iTaxPrice,ps.dArriveDate,ps.cItemCode,p.cMaker  
from @u8.PO_Pomain p left join @u8.PO_Podetails ps on p.POID = ps.POID  
    left join @u8.vendor v on v.cVenCode = p.cVenCode  
    left join @u8.Inventory I on i.cInvCode = ps.cInvCode  
    left join  UFDLImport..AuditGrade A on A.cInvCode = ps.cInvCode and A.accid = '200'  
    left join (select max(AuditState) as AuditState,POID from UFDLImport..PO_Pomain_Import i left join dbo._UserInfo u on i.audituid =u.vchrUid where accid = '200' and i.accyear = 'aaaaaa' and i.accid = '200' group by POID ) pM on pM.POID = p.POID 
where ps.cbCloser is null and cCloser is null and isnull(iReceivedQTY,0) = 0  
";
            sSQL = sSQL.Replace("aaaaaa", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            sSQL = sSQL.Replace("bbbbbb", lAuditGrade.Text.Trim());


            if (lookUpEditCreate != null && lookUpEditCreate.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cMaker  = '" + lookUpEditCreate.Text.Trim() + "' ";
            }
            if (chkDate1.Checked)
            {
                sSQL = sSQL + " and dPODate  >= '" + dateEdit1.DateTime + "' ";
                sSQL = sSQL + " and dPODate  <= '" + dateEdit2.DateTime + "' ";
            }
            if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cVenCode = '" + txtVenCode.Text.ToString().Trim() + "' ";
            }
            if (lookUpCode1.EditValue != null && lookUpCode1.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID >= '" + lookUpCode1.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpCode2.EditValue != null && lookUpCode2.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and p.cPOID <= '" + lookUpCode2.EditValue.ToString().Trim() + "' ";
            }
            if (lookUpItem.EditValue != null && lookUpItem.EditValue.ToString().Trim() != string.Empty)
            {
                sSQL = sSQL + " and ps.cItemCode = '" + lookUpItem.EditValue.ToString().Trim() + "' ";
            }
            if (txtDepName.Text.Trim() != "")
            {
                sSQL = sSQL + " and p.cDepCode = '" + txtDepCode.Text.Trim() + "' ";
            }
            sSQL = sSQL + "  order by p.cPOID,ps.cInvCode";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;
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

        private void lookUpEditCreate_EditValueChanged(object sender, EventArgs e)
        {
            btnGet();
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    btnGet();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！   " + ee.Message);
            }
        }

        private void clsMail_Load(object sender, EventArgs e)
        {

        }
    }
}