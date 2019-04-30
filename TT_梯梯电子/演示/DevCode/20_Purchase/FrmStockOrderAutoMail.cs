using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace Purchase
{
    public partial class FrmStockOrderAutoMail : FrameBaseFunction.Frm�б���ģ��
    {
        public FrmStockOrderAutoMail()
        {
            InitializeComponent();
        }

        private void FrmStockOrderAutoMail_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void GetGridView()
        {
            try
            {
                string sSQL = "select ReturnRemark,(case isnull(bAgain,0) when 1 then '��' else '' end) as bAgain,p.cVenCode,v.cVenName,'' as bChoose,ps.ID,p.cPOID,dPODate,ps.dArriveDate,ps.cInvCode,i.cInvName,i.cInvStd,ps.cItemCode,ps.iQuantity,ps.iNum,ps.iUnitPrice,ps.iMoney,ps.iTax,ps.iSum,ps.iTaxPrice,ps.iPerTaxRate,ps.id," +
                                            " pI.ReturnDate1,pI.ReturnDate2,pI.ReturnAudit,pI.ReturnAuditDate,pI.ReturnAuditUID,pI.ReturnApply,pI.ReturnAuditCount,p.cMaker,d.cDepCode,d.cDepName,p.cMemo,  " +
                                             " (case isnull(pI.bLock,0) when 1 then 'Y' else '' end)  as bLock,pI.Locker,pI.LockDate, " +
                                        " (ps.iQuantity - isnull(ps.iArrQTY,0) - isnull(ps.iReceivedQTY,0)) as iQtyUnIn, " +
                                        " (ps.iNum - isnull(ps.iArrNum,0) - isnull(ps.iReceivedNum,0)) as iNumUnIn,ReturnUid,ReturnUidDate,e.�������� as ���ڼƻ�����,f.�������� as �����ƻ���������,0 as bTomato,pI.UnLockTomatoUser,pI.UnLockTomatoDate " +
                               "from @u8.PO_Podetails ps inner join @u8.PO_Pomain p on p.POID = ps.POID left join dbo.PO_Podetails_Import pI on pI.PO_PodetailsID = ps.ID and accid = 200 and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' left join @u8.Inventory I on I.cInvCode = ps.cInvCode   left join @u8.Vendor v on v.cVenCode = p.cVenCode left join @u8.Department d on d.cDepCode = p.cDepCode " +
                                    "left join (select ���۶�����,�Ӽ�����,min(��������) as �������� from DolleDatabase.dbo.OmPlanProduction group by ���۶�����,�Ӽ�����) e on e.���۶����� = ps.cItemCode and e.�Ӽ����� = ps.cInvCode " +
                                    "left join (select ���۶�����,�Ӽ�����,max(��������) as �������� from DolleDatabase.dbo.OmPlanProduction where �Ƿ��� = 'Y' group by ���۶�����,�Ӽ�����) f on f.���۶����� = ps.cItemCode and f.�Ӽ����� = ps.cInvCode " +
                               "where  iverifystateex = 2  and isnull(cCloser,'') = '' and isnull(cbCloser,'') = '' and iQuantity > (isnull(iReceivedQTY,0) + isnull(iArrQTY,0))  ";

                sSQL = sSQL + " and ((isnull(ReturnAudit,0) <> 1 and  pI.ReturnDate1 is not null and isnull(ReturnApply,0) = 0) or (isnull(ReturnApply,0) = 1 and isnull(ReturnAudit,0) = 1)) ";

                sSQL = sSQL + " order by p.cVenCode,id ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
               
                if (dt == null || dt.Rows.Count == 0)
                {
                    gridControl2.DataSource = null;
                }
                else
                {
                    gridControl2.DataSource = dt;

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, gridColcVenCode).ToString().Trim() == "0623" || gridView2.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "���ֱ������ӡ")
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
                        if (gridView2.GetRowCellValue(i, gridCol�����ƻ���������) != null && gridView2.GetRowCellValue(i, gridCol�����ƻ���������).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol�����ƻ���������).ToString()).ToString("yyyy-MM-dd"));
                        else if (gridView2.GetRowCellValue(i, gridCol���ڼƻ�����) != null && gridView2.GetRowCellValue(i, gridCol���ڼƻ�����).ToString().Trim() != "")
                            d2 = DateTime.Parse(DateTime.Parse(gridView2.GetRowCellValue(i, gridCol���ڼƻ�����).ToString()).ToString("yyyy-MM-dd"));

                        if (d1 > d2 || d1 < d3)
                        {
                            gridView2.SetRowCellValue(i, gridColbTomato, 1);
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
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����б�ʧ�ܣ�  " + ee.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dNow = DateTime.Now;
            if (dNow.ToString("HH:mm:ss") == "05:00:00")
            {
                GetGridView();

                DataTable dtView = (DataTable)gridControl2.DataSource;
                string sTxt = "";

                
                for (int i = 0; i < dtView.Rows.Count; i++)
                {
                    if (dtView.Rows[i]["bTomato"].ToString().Trim() == "1")
                    {
                        sTxt = sTxt + "\n����:" + dtView.Rows[i]["cInvCode"].ToString().Trim() + " ������:" + dtView.Rows[i]["cPOID"].ToString().Trim() + ";  ";
                    }
                }

                if (sTxt == string.Empty)
                { 
                    return;
                }

                string sSQL = " SELECT u.uid, u.bVend, u.sEMail, u.POAduditGrade, u.AccID, u.AccYear, b.vchrName,b.cDepCode " +
                        "FROM UFDLImport.._vendUid u inner join dbo._UserInfo b on u.uid = b.vchrUid " +
                        "WHERE accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and accid = '200'  and b.cDepCode = '802' and sEMail is not null";
                DataTable dtMailAddress = clsSQLCommond.ExecQuery(sSQL);
                if (dtMailAddress == null || dtMailAddress.Rows.Count < 1)
                {
                    return;
                }

                FrmMailListSend frmMail = new FrmMailListSend();

                DataRow drMail = frmMail.dt.NewRow();
                drMail["Subject"] = "�����ƻ�δ�����Զ���������";


                sTxt = "���²ɹ����ϱ��������������\n" + sTxt;
                drMail["sText"] = sTxt;
                drMail["bUsed"] = "-1";
                for (int i = 0; i < dtMailAddress.Rows.Count; i++)
                {
                    drMail["mailAddress"] = drMail["mailAddress"] + dtMailAddress.Rows[i]["sEMail"].ToString().Trim() + ";";
                    drMail["mailPerID"] = drMail["mailPerID"] + dtMailAddress.Rows[i]["uid"].ToString().Trim() + ";";
                    drMail["mailPer"] = drMail["mailPer"] + dtMailAddress.Rows[i]["vchrName"].ToString().Trim() + ";";
                }
                drMail["sMailCC"] = "dolle_sz@126.com;121921624@qq.com";
                frmMail.dt.Rows.Add(drMail);

                try
                {
                    frmMail.sDO = "�Զ������ɹ�����";
                    frmMail.FrmMailListSend_Load(null, null);
                    frmMail.btnOK_Click(null, null);
                    //frmMail.ShowDialog();
                }
                catch { }
            }
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
    }
}