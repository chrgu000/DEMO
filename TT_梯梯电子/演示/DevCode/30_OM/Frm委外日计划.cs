using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using FrameBaseFunction;


namespace OM
{
    public partial class Frmί���ռƻ� : FrameBaseFunction.Frm�б���ģ��
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();

        //TH.BaseForm.ClsGetSQL clsGetSQL = new TH.BaseForm.ClsGetSQL();
        bool bGetOrLoad = false;    //������ true����� �ռƻ���ѯ false
        bool bBtnType = false;      //������ false��������� True
        DataTable dtOMPlanDay;
        
 
        //ClsVenInvPrice clsPrice = new ClsVenInvPrice();
        private DataTable dt��Ӧ�̴���۸� = null;

        //string sFocusCol = "";
        public DataTable dtOM;

        public Frmί���ռƻ�()
        {
            InitializeComponent();

            //layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            //base.layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            CreateMergetEditControl();
            CreateMergebEditControl();
            CreateMergedEditControl();
            CreateMerged2EditControl();
        }



        #region ��ť����
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClosed();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    default:
                        break;
                }

                //sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

        DataTable dt���� = new DataTable();

        private void btnAdd()
        {

        }

        #region ��ťģ��

        ///// <summary>
        ///// �������Lookup֮��ı���ID������ת����Text���ڴ�ӡ
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //    DataColumn dc = new DataColumn();
            //    dc.ColumnName = "StateText";
            //    dt.Columns.Add(dc);

            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //        if (drState.Length > 0)
            //        {
            //            dt.Rows[i]["StateText"] = drState[0]["State"];
            //        }

            //    }

            return dt;
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        private void btnPrint()
        {
            
        }
        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLayout(string sText)
        {
            //if (layoutControl1 == null) return;
            //if (sText == "����")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "���沼��";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "����";

            //    DialogResult d = MessageBox.Show("�Ƿ񱣴�?\n�ǣ����������ʽ\n�񣺻ָ�Ĭ�Ͻ�����ʽ,�´μ���ʱ����Ĭ����ʽ��\n", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
        }
        #endregion

        /// <summary>
        /// ����
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void btnRefresh()
        {

        }

        private string sFrmSEL = "";

        /// <summary>
        /// ���ί��ƻ�
        /// </summary>
        private void btnSel()
        {
            try
            {
                //   ��üƻ�������һ��һ��һ�Զ�
                dtOMPlanDay = new DataTable();
                chkAll.Checked = false;

                string sSQL = @"

execute 111111.dbo._GetOMPlanDay '222222','333333','444444','555555' ;

select distinct cast(0 as bit) as ѡ��, oII.cCode,cast (null as decimal(16,2)) as iSumOutQty,cast (null as decimal(16,2)) as iYuQty,0 as bEdit
    ,case when isnull(o.iID,0)=0 then 0 else 1 end as bCreateDayPlan,d.cDepName,T.*,DateDiff(day,isnull(WorkDate,'2099-12-31'),T.date2) as WorkDateDel
    ,DateDiff(day,isnull(PODate,'2099-12-31'),T.date2)  as PODateDel,DateDiff(day,isnull(OMDate,'2099-12-31'),T.date2)  as OMDateDel,oII.EnSureUser
    ,oII.EnSureDate,oII.EnSureDepment,d.cDepCode,T.ImportDate,isnull(T.RemarkXB,'9999-99') as RemarkXB ,i.iInvAdvance as ��������,cast(null as int) as �ƻ����� ,cast(null as int) as ��������ѹ��
from @u8.TempOMPlanDay T left join @u8.vendor v on T.cVenCode = v.cVenCode left join @u8.Department d on v.cVenDepart = d.cDepCode 
   left join UFDLImport..OMPlanDay o on T.iID = o.iID and o.cCode like '666666%' 
   left join UFDLImport..OMPlanDay_Info oII on oII.iID = T.iID and oII.cCode = '666666' 
   inner join @u8.Inventory i on i.cInvCode = t.invcode
where 1=1 
order by isnull(T.RemarkXB,'9999-99') , T.iID,T.socode,T.soseq,T.invcode
";

                sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName);
                sSQL = sSQL.Replace("222222", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("333333", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("444444", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("555555", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                sSQL = sSQL.Replace("666666", DateTime.Parse(datePlan.Text).ToString("yyMMdd"));

                if (lookUpEditSOCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoCode = '" + lookUpEditSOCode.Text.Trim() + "'");
                }
                if (lookUpEditiRow1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "'");
                }
                if (lookUpEditiRow2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "'");
                }
                if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.cVenCode = '" + txtVenCode.Text.Trim() + "'");
                }
                if (radioQtyCurr.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(T.CurrQtyI,0) > 0");
                }
                if (radioQtyCanUse.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(T.CanUseQty,0) > 0");
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "invSM";        //ĸ������
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "invSZ";        //�Ӽ�����
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "QtyInYuI";     //�������
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "iType";        //ί��ƻ�������Դ��ʶ��1 ���ɶ�����2 ί��ƻ���Դί��ƻ���3 ��Դ����ƻ�
                dt.Columns.Add(dc);

                //sSQL = "select o.*,i.iInvAdvance from DolleDatabase.dbo.OmPlanProduction o left join @u8.inventory i on i.cInvCode = o.���ϱ��� where �Ƿ��� = 'Y' order by �������� desc ";

                sSQL = @"
select b.��������� as ������,b.���ϱ���
	,a.���۶�����,a.���۶����к�,e.�Ӽ�����
	,min(c.�ƻ���������) as ��������,max(c.�ƻ���������) as ����������
from XWSystemDB_DL.dbo.�����ƻ� a inner join XWSystemDB_DL.dbo.�����ƻ���ϸ b on a.���ݺ� = b.��ͷ���ݺ� and a.���׺� = b.���׺� and a.���׺� = '200'
	inner join XWSystemDB_DL.dbo.�����ռƻ� c on b.iID = c.�����ƻ���ϸiID
	inner join @u8.inventory d on d.cInvCode = b.���ϱ���
	left join (
					select a.MoCode,b.InvCode as ���ϱ���,c.InvCode as �Ӽ�����
					from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid
						inner join @u8.mom_moallocate c on b.MoDId = c.MoDId
			   )e on e.MoCode = b.��������� and b.���ϱ��� = e.���ϱ���
where �Ų����� = (select MAX(�Ų�����) from XWSystemDB_DL.dbo.�����ռƻ�)
group by b.���������,b.���ϱ���,a.���۶�����,a.���۶����к�,e.�Ӽ�����
";
                sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));

                DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                if (dt2.Rows.Count < 1)
                {
                    MessageBox.Show("����Ч�����ƻ�����Դ���뵼�������ƻ�������");
                    return;
                }

                sSQL = "select * from UFDLImport..OMPlan where accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(bClosed,0) <> 1 ";
                DataTable dt3 = clsSQLCommond.ExecQuery(sSQL);

                DataTable dtVen = null;

                //��Ӧ�̷ֹܲ���
                sSQL = "select distinct v.cVenDepart as cDepCode,d.cDepName,v.cVenCode from @u8.vendor v left join @u8.Department d on v.cVenDepart = d.cDepCode where v.cVenDepart is not null order by v.cVenDepart,d.cDepName ";
                DataTable dtVenDep = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["QtyInYuI"] = Convert.ToDouble(dt.Rows[i]["QtyInI"]) - Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]);
                    if (dt.Rows[i]["iSupplyType"].ToString().Trim() == "3") //����
                    {
                        if (dt != null && dt.Rows.Count != 0 && dt.Rows[i]["iSendT"].ToString().Trim() != "")
                        {
                            //�����µ�
                            double iSendT = 0;
                            if (dt.Rows[i]["iSendT"].ToString().Trim() != "")
                            {
                                iSendT = Math.Floor(Convert.ToDouble(dt.Rows[i]["iSendT"]));
                            }
                            dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]) - iSendT;
                        }
                        else
                        {
                            //�����µ�
                            dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]);
                        }
                    }
                    if (dt.Rows[i]["ʹ������"] == null || dt.Rows[i]["ʹ������"].ToString().Trim() == "")
                    {
                        continue;
                    }
                    decimal dec1 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["ʹ������"]), 6);
                    decimal dec4 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["QtyNow"]), 6);
                    if (dt.Rows[i]["ChangeRate"] != null && dt.Rows[i]["ChangeRate"].ToString().Trim() != "")
                    {
                        decimal d = decimal.Round(Convert.ToDecimal(dt.Rows[i]["ChangeRate"]), 6);
                        dt.Rows[i]["iNumI"] = decimal.Round(dec4 * dec1 / d, 6);
                    }
                    dt.Rows[i]["iQuantityI"] = dec4 * dec1;

                    string sInvSM = "";
                    if (Convert.ToBoolean(dt.Rows[i]["bPurchaseM"]))
                    {
                        sInvSM = sInvSM + "�⹺ ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bSelfM"]))
                    {
                        sInvSM = sInvSM + "���� ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bProxyForeignM"]))
                    {
                        sInvSM = sInvSM + "ί�� ";
                    }
                    dt.Rows[i]["invSM"] = sInvSM;
                    string sInvSZ = "";
                    if (Convert.ToBoolean(dt.Rows[i]["bPurchase"]))
                    {
                        sInvSZ = sInvSZ + "�⹺ ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bSelf"]))
                    {
                        sInvSZ = sInvSZ + "���� ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bProxyForeign"]))
                    {
                        sInvSZ = sInvSZ + "ί�� ";
                    }
                    dt.Rows[i]["invSZ"] = sInvSZ;

                    dt.Rows[i]["StartDate2"] = Convert.ToDateTime(datePlan.Text);
                    string sInvCode1 = dt.Rows[i]["InvCode"].ToString().Trim();                     //ί��ĸ��
                    string sSoCode = "";                                                            //���۶�����
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //���۶�����
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }

                    //��Ӧ�̼��۸�
                    if (dt.Rows[i]["cVenCode"] == null || dt.Rows[i]["cVenCode"].ToString().Trim() == "")
                    {
                        dtVen = GetVendPriceInfo(sInvCode1);
                        if (dtVen != null && dtVen.Rows.Count > 0)
                        {
                            dt.Rows[i]["cVenCode"] = dtVen.Rows[0]["cVenCode"].ToString().Trim();
                            dt.Rows[i]["cVenName"] = dtVen.Rows[0]["cVenName"];
                            dt.Rows[i]["iTaxPrice"] = dtVen.Rows[0]["iTaxPrice"];
                            dt.Rows[i]["iTaxRate"] = dtVen.Rows[0]["iTaxRate"];
                        }
                    }

                    if (dt.Rows[i]["iTaxPrice"] == null || dt.Rows[i]["iTaxPrice"].ToString().Trim() == "" || BaseFunction.ReturnDecimal(dt.Rows[i]["iTaxPrice"]) <= 0)
                    {
                        DataTable dtVenPrice = GetVendPriceInfo(sInvCode1, dt.Rows[i]["cVenCode"].ToString().Trim());
                        if (dtVenPrice != null && dtVenPrice.Rows.Count > 0)
                        {
                            dt.Rows[i]["iTaxPrice"] = dtVenPrice.Rows[0]["iTaxPrice"];
                            dt.Rows[i]["iTaxRate"] = dtVenPrice.Rows[0]["iTaxRate"];
                        }
                    }

                    if (dt.Rows[i]["cVenCode"] != null && dt.Rows[i]["cVenCode"].ToString().Trim() != "")
                    {
                        DataRow[] dr = dtVenDep.Select(" cVenCode = '" + dt.Rows[i]["cVenCode"].ToString().Trim() + "'");
                        if (dr.Length > 0)
                        {
                            dt.Rows[i]["cDepCode"] = dr[0]["cDepCode"].ToString().Trim();
                        }
                    }

                    double d1 = Convert.ToDouble(dt.Rows[i]["iInvAdvance"]);                        //ί��ĸ���ӹ�����

                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //ί���Ӽ�
                    double d2 = Convert.ToDouble(dt.Rows[i]["iInvAdvance2"]);                       //ί���Ӽ��ӹ�����

                    #region ��������� = Min(������������ڣ�ί���������ڣ��ɹ���������ڣ�datePlan)
                    DateTime dDayIn = datePlan.DateTime;
                    if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")   //�ɹ������
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["PODate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")   //ί������
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")   //ί������
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    #endregion

                    #region 1. �������������Ӽ���Դί�ⶩ��
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        string swInvCode1 = dt2.Rows[j]["�Ӽ�����"].ToString().Trim();              //���������Ӽ�
                        string swInvCode2 = dt2.Rows[j]["���ϱ���"].ToString().Trim();              //��������ĸ��
                        string sSoCodeW = dt2.Rows[j]["���۶�����"].ToString().Trim();              //���۶�����
                        string sSoSeqW = dt2.Rows[j]["���۶����к�"].ToString().Trim();             //���۶����к�

                        if (swInvCode1 == sInvCode1 && sSoCodeW == sSoCode && sSoSeq == sSoSeqW)     //����������Ҫί�����Ϊ�Ӽ�
                        {
                            if (dt2.Rows[j]["��������"] != null && dt2.Rows[j]["��������"].ToString().Trim() != "")
                            {
                                DateTime dDate1 = Convert.ToDateTime(dt2.Rows[j]["��������"]);
                                //double d11 = Convert.ToDouble(dt2.Rows[j]["iInvAdvance"]);                  //�����������ϼӹ�����
                                double d11 = 2;

                                DateTime dNeed = dDate1;       //��������
                                if (dNeed.AddDays(0 - 3) <= dDayIn)
                                {
                                    dNeed = dDayIn;
                                }
                                else
                                {
                                    dNeed = dNeed.AddDays(0 - 3);
                                }

                                dt.Rows[i]["date2"] = dNeed.ToString("yyyy-MM-dd");                         //�������� = ���������Ӽ��������� = ���������������� - �ӹ�����   

                                DateTime dNOut = dNeed;                                                     //�����������
                                if (dNOut.AddDays(0 - d1) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                                {
                                    dt.Rows[i]["date1"] = DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    dt.Rows[i]["date1"] = dNOut.AddDays(0 - d1).ToString("yyyy-MM-dd");    //����������� = �������� - ί��ӹ����� 
                                }
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "����";
                                }
                            }
                        }
                    }
                    #endregion
                }

                #region  3. ������û�����ڵ����ݰ���ί���ƻ�������д
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) == DateTime.Parse("1900-01-01"))
                    {
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            if (dt3.Rows[j]["iID"].ToString().Trim() == dt.Rows[i]["iID"].ToString().Trim())
                            {
                                dt.Rows[i]["date1"] = dt3.Rows[j]["StartDate"].ToString().Trim();
                                dt.Rows[i]["date2"] = dt3.Rows[j]["DueDate"].ToString().Trim();
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "��";
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 2. ί������ĸ����Դί��ƻ��Ӽ� ִ�����������©
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //2. ί������ĸ����Դί��ƻ��Ӽ�
                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //ί���Ӽ�
                    string sSoCode = "";                                                            //���۶�����
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //���۶�����
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["date2"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[j]["date2"]) > DateTime.Parse("2000-01-01") && dt.Rows[j]["iType"].ToString().Trim() != "��")
                        {
                            continue;
                        }
                        string sSoCodeOM = "";                                                   //���۶�����
                        if (dt.Rows[j]["SoCode"] != null && dt.Rows[j]["SoCode"].ToString().Trim() != "")
                        {
                            sSoCodeOM = dt.Rows[j]["SoCode"].ToString().Trim();
                        }
                        string sSoSeqOM = "";                                                   //���۶����к�
                        if (dt.Rows[j]["SoSeq"] != null && dt.Rows[j]["SoSeq"].ToString().Trim() != "")
                        {
                            sSoSeqOM = dt.Rows[j]["SoSeq"].ToString().Trim();
                        }
                        string sInvCodeOM = dt.Rows[j]["InvCode"].ToString().Trim();           //ί��ƻ�ĸ��
                        if (sInvCode2 == sInvCodeOM && sSoCodeOM == sSoCode && sSoSeq == sSoSeqOM)
                        {
                            dt.Rows[j]["date2"] = Convert.ToDateTime(dt.Rows[i]["date1"]).AddDays(-1);        //�������� = ��һ���Ӽ��������� = ��һ��BOMί��ĸ�������������
                            double dInvAdvance = 0;
                            if (dt.Rows[j]["iInvAdvance"].ToString().Trim() != "")
                            {
                                dInvAdvance = Convert.ToDouble(dt.Rows[j]["iInvAdvance"]);
                            }
                            dt.Rows[j]["date1"] = Convert.ToDateTime(dt.Rows[j]["date2"]).AddDays(0 - dInvAdvance);        //����������� = �������� - �ӹ�����
                            if (dt.Rows[j]["iType"].ToString().Trim() == "" || dt.Rows[j]["iType"].ToString().Trim() == "��")
                            {
                                dt.Rows[j]["iType"] = "ί��";
                            }
                        }
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //2. ί������ĸ����Դί��ƻ��Ӽ�(��һ�Σ�Ԥ����BOM�㼶չ��˳����dt˳��һ����ɵ���©)
                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //ί���Ӽ�
                    string sSoCode = "";                                                            //���۶�����
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //���۶�����
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["date2"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[j]["date2"]) >= DateTime.Parse("2000-01-01") && dt.Rows[j]["iType"].ToString().Trim() != "��")
                        {
                            continue;
                        }
                        string sSoCodeOM = "";                                                   //���۶�����
                        if (dt.Rows[j]["SoCode"] != null && dt.Rows[j]["SoCode"].ToString().Trim() != "")
                        {
                            sSoCodeOM = dt.Rows[j]["SoCode"].ToString().Trim();
                        }
                        string sSoSeqOM = "";                                                   //���۶����к�
                        if (dt.Rows[j]["SoSeq"] != null && dt.Rows[j]["SoSeq"].ToString().Trim() != "")
                        {
                            sSoSeqOM = dt.Rows[j]["SoSeq"].ToString().Trim();
                        }
                        string sInvCodeOM = dt.Rows[j]["InvCode"].ToString().Trim();           //ί��ƻ�ĸ��
                        if (sInvCode2 == sInvCodeOM && sSoCodeOM == sSoCode && sSoSeq == sSoSeqOM)
                        {
                            dt.Rows[j]["date2"] = Convert.ToDateTime(dt.Rows[i]["date1"]).AddDays(-1);                        //�������� = ��һ���Ӽ��������� = ��һ��BOMί��ĸ�������������
                            double dInvAdvance = 0;
                            if (dt.Rows[j]["iInvAdvance"].ToString().Trim() != "")
                            {
                                dInvAdvance = Convert.ToDouble(dt.Rows[j]["iInvAdvance"]);
                            }
                            dt.Rows[j]["date1"] = Convert.ToDateTime(dt.Rows[j]["date2"]).AddDays(0 - dInvAdvance);        //����������� = �������� - �ӹ�����
                            if (dt.Rows[j]["iType"].ToString().Trim() == "" || dt.Rows[j]["iType"].ToString().Trim() == "��")
                            {
                                dt.Rows[j]["iType"] = "ί��";
                            }
                        }
                    }

                }
                #endregion
                #region  3. ������û�����ڵ����ݰ���ί���ƻ�������д
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) == DateTime.Parse("1900-01-01"))
                    {
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            if (dt3.Rows[j]["iID"].ToString().Trim() == dt.Rows[i]["iID"].ToString().Trim())
                            {
                                dt.Rows[i]["date1"] = dt3.Rows[j]["StartDate"].ToString().Trim();
                                dt.Rows[i]["date2"] = dt3.Rows[j]["DueDate"].ToString().Trim();
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "��";
                                }
                            }
                        }
                    }
                }
                #endregion
                #region  4 ��������������ڼƻ����ڵĲ��üƻ�����
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date1"]) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                    {
                        dt.Rows[i]["date1"] = datePlan.DateTime.ToString("yyyy-MM-dd");
                        dt.Rows[i]["bEdit"] = 1;
                        if (dt.Rows[i]["iType"].ToString().Trim() == "")
                        {
                            dt.Rows[i]["iType"] = "��";
                        }
                    }
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                    {
                        dt.Rows[i]["date2"] = datePlan.DateTime.ToString("yyyy-MM-dd");
                        dt.Rows[i]["bEdit"] = 1;
                        if (dt.Rows[i]["iType"].ToString().Trim() == "")
                        {
                            dt.Rows[i]["iType"] = "��";
                        }
                    }
                }
                #endregion

                #region ���깤����

                sSQL = "select distinct a.sid as ���۶�����,a.cInvCode as ���ϱ���,a.PID as ���������,d.InvCode as �Ӽ����� " +
                        "from DolleDatabase..ShortMaterielPlanFinish a inner join @u8.mom_order b on a.PID = b.MoCode " +
                            "inner join @u8.mom_orderdetail c on a.cInvCode = c.InvCode and b.MOID = c.moid " +
                            "inner join @u8.mom_moallocate d on d.MoDId = c.Modid";
                DataTable dtPClose = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sSoCode = dt.Rows[i]["SoCode"].ToString().Trim().ToLower();
                    string sInvCode = dt.Rows[i]["InvCode"].ToString().Trim().ToLower();

                    for (int j = 0; j < dtPClose.Rows.Count; j++)
                    {
                        string sSoCode2 = dtPClose.Rows[j]["���۶�����"].ToString().Trim().ToLower();
                        string sInvCode2 = dtPClose.Rows[j]["�Ӽ�����"].ToString().Trim().ToLower();

                        if (sSoCode == sSoCode2 && sInvCode == sInvCode2)
                        {
                            dt.Rows[i]["iType"] = "���깤";
                            break;
                        }
                    }
                }


                #endregion

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["cVenCode"] = dt.Rows[i]["cVenCode"].ToString().Trim();

                    DateTime D1 = DateTime.Parse("1900-01-01");
                    if (dt.Rows[i]["date1"] != null && dt.Rows[i]["date1"].ToString().Trim() != "")
                    {
                        D1 = Convert.ToDateTime(dt.Rows[i]["date1"]);
                    }
                    DateTime D2 = DateTime.Parse("1900-01-01");
                    if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                    {
                        D2 = Convert.ToDateTime(dt.Rows[i]["date2"]);
                    }


                    //if (dt.Rows[i]["invcode"].ToString().Trim() == "WW030222020004")
                    //{

                    //}
                    double d1 = 0;
                    if (dt.Rows[i]["iSendT"] != null && dt.Rows[i]["iSendT"].ToString().Trim() != "")
                    {
                        d1 = Convert.ToDouble(dt.Rows[i]["iSendT"]);
                    }
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        if (Convert.ToDouble(dt.Rows[i]["iID"]) == Convert.ToDouble(dt.Rows[j]["iID"]))
                        {
                            DateTime D3 = DateTime.Parse("1900-01-01");
                            if (dt.Rows[j]["date1"] != null && dt.Rows[j]["date1"].ToString().Trim() != "")
                            {
                                D3 = Convert.ToDateTime(dt.Rows[j]["date1"]);
                            }
                            DateTime D4 = DateTime.Parse("1900-01-01");
                            if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "")
                            {
                                D4 = Convert.ToDateTime(dt.Rows[j]["date2"]);
                            }

                            double d11 = 0;
                            if (dt.Rows[j]["iSendT"] != null && dt.Rows[j]["iSendT"].ToString().Trim() != "")
                            {
                                d11 = Convert.ToDouble(dt.Rows[j]["iSendT"]);
                            }
                            if (d1 > d11)
                            {
                                d1 = d11;
                                dt.Rows[i]["iSendT"] = d1;
                            }

                            if (D1 < D3)
                            {
                                D1 = D3;
                                dt.Rows[i]["date1"] = D3;
                            }
                            if (D2 < D4)
                            {
                                D2 = D4;
                                dt.Rows[i]["date2"] = D4;
                            }
                        }
                    }
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        if (Convert.ToDouble(dt.Rows[i]["iID"]) == Convert.ToDouble(dt.Rows[j]["iID"]))
                        {
                            dt.Rows[j]["date2"] = D2;
                            dt.Rows[j]["date1"] = D1;
                        }
                    }
                    if (D2 > DateTime.Parse("1901-01-01"))
                    {
                        dt.Rows[i]["date2"] = D2.ToString("yyyy-MM-dd");
                        dt.Rows[i]["date1"] = D1.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dt.Rows[i]["date2"] = DBNull.Value;
                        dt.Rows[i]["date1"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                    {
                        if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                            dt.Rows[i]["WorkDateDel"] = ts.Days;
                        }
                        if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                            dt.Rows[i]["OMDateDel"] = ts.Days;
                        }
                        if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["PODate"]);
                            dt.Rows[i]["PODateDel"] = ts.Days;
                        }
                    }
                    #region �������� = �ִ��� + ����⣨�����������������֮ǰ��

                    double da1 = 0;              //�ִ�������
                    double da2 = 0;              //�ɹ����������
                    double da3 = 0;              //ί����������
                    double da4 = 0;              //�������������
                    double da5 = 0;              //�ۼƿ�������
                    double dd1 = 0;              //�ִ����
                    double dd2 = 0;              //�ɹ���������
                    double dd3 = 0;              //ί���������
                    double dd4 = 0;              //������������
                    double dd5 = 0;              //�ۼƿ��ü���
                    DateTime dTime1 = DateTime.Parse("2099-12-31");            //�����������
                    DateTime dTime2 = DateTime.Parse("2099-12-31");            //�ɹ����������
                    DateTime dTime3 = DateTime.Parse("2099-12-31");            //ί����������
                    DateTime dTime4 = DateTime.Parse("2099-12-31");            //�������������

                    if (dt.Rows[i]["CurrQtyI"] != null && dt.Rows[i]["CurrQtyI"].ToString().Trim() != "")
                    {
                        da1 = Convert.ToDouble(dt.Rows[i]["CurrQtyI"]);
                    }
                    if (dt.Rows[i]["POQtyI"] != null && dt.Rows[i]["POQtyI"].ToString().Trim() != "")
                    {
                        da2 = Convert.ToDouble(dt.Rows[i]["POQtyI"]);
                    }
                    if (dt.Rows[i]["OMQtyI"] != null && dt.Rows[i]["OMQtyI"].ToString().Trim() != "")
                    {
                        da3 = Convert.ToDouble(dt.Rows[i]["OMQtyI"]);
                    }
                    if (dt.Rows[i]["WorkQtyI"] != null && dt.Rows[i]["WorkQtyI"].ToString().Trim() != "")
                    {
                        da4 = Convert.ToDouble(dt.Rows[i]["WorkQtyI"]);
                    }
                    if (dt.Rows[i]["CurrNumI"] != null && dt.Rows[i]["CurrNumI"].ToString().Trim() != "")
                    {
                        dd1 = Convert.ToDouble(dt.Rows[i]["CurrNumI"]);
                    }
                    if (dt.Rows[i]["PONumI"] != null && dt.Rows[i]["PONumI"].ToString().Trim() != "")
                    {
                        dd2 = Convert.ToDouble(dt.Rows[i]["PONumI"]);
                    }
                    if (dt.Rows[i]["OMNumI"] != null && dt.Rows[i]["OMNumI"].ToString().Trim() != "")
                    {
                        dd3 = Convert.ToDouble(dt.Rows[i]["OMNumI"]);
                    }
                    if (dt.Rows[i]["WorkNumI"] != null && dt.Rows[i]["WorkNumI"].ToString().Trim() != "")
                    {
                        dd4 = Convert.ToDouble(dt.Rows[i]["WorkNumI"]);
                    }
                    if (dt.Rows[i]["date1"] != null && dt.Rows[i]["date1"].ToString().Trim() != "")
                    {
                        dTime1 = Convert.ToDateTime(dt.Rows[i]["date1"]);
                    }
                    if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")
                    {
                        dTime2 = Convert.ToDateTime(dt.Rows[i]["PODate"]);
                    }
                    if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")
                    {
                        dTime3 = Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                    }
                    if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")
                    {
                        dTime4 = Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                    }
                    da5 = da1;
                    dd5 = dd1;
                    if (dTime1 > dTime2)
                    {
                        da5 = da5 + da2;
                        dd5 = dd5 + dd2;
                    }
                    if (dTime1 > dTime3)
                    {
                        da5 = da5 + da3;
                        dd5 = dd5 + dd3;
                    }
                    if (dTime1 > dTime4)
                    {
                        da5 = da5 + da4;
                        dd5 = dd5 + dd4;
                    }
                    dt.Rows[i]["CanUseQty"] = da5;
                    dt.Rows[i]["CanUseNum"] = dd5;
                    #endregion

                    #region ������ʾ��ʽ  0����ʾ
                    if (dt.Rows[i]["PlanQty"] != null && dt.Rows[i]["PlanQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["PlanQty"]) != 0) //�Ӽ��ۼƷ�������
                    {
                        dt.Rows[i]["PlanQty"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]);
                    }
                    else
                    {
                        dt.Rows[i]["PlanQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendQTYZ"] != null && dt.Rows[i]["iSendQTYZ"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]) != 0) //�Ӽ��ۼƷ�������
                    {
                        dt.Rows[i]["iSendQTYZ"] = Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]);
                    }
                    else
                    {
                        dt.Rows[i]["iSendQTYZ"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendNumZ"] != null && dt.Rows[i]["iSendNumZ"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendNumZ"]) != 0) //�Ӽ��ۼƷ��ϼ���
                    {
                        dt.Rows[i]["iSendNumZ"] = Convert.ToDouble(dt.Rows[i]["iSendNumZ"]);
                    }
                    else
                    {
                        dt.Rows[i]["iSendNumZ"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendT"] != null && dt.Rows[i]["iSendT"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendT"]) != 0)   //ĸ���ۼƷ�������
                    {
                        dt.Rows[i]["iSendT"] = Math.Floor(Convert.ToDouble(dt.Rows[i]["iSendT"]));
                    }
                    else
                    {
                        dt.Rows[i]["iSendT"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["DidQty"] != null && dt.Rows[i]["DidQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["DidQty"]) != 0)   //����������
                    {
                        dt.Rows[i]["DidQty"] = Math.Floor(Convert.ToDouble(dt.Rows[i]["DidQty"]));
                    }
                    else
                    {
                        dt.Rows[i]["DidQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iNumI"] != null && dt.Rows[i]["iNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iNumI"]) != 0)   //�Ӽ�����
                    {
                        dt.Rows[i]["iNumI"] = Convert.ToDouble(dt.Rows[i]["iNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["iNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyInYuI"] != null && dt.Rows[i]["QtyInYuI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyInYuI"]) != 0)   //�������
                    {
                        dt.Rows[i]["QtyInYuI"] = Convert.ToDouble(dt.Rows[i]["QtyInYuI"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyInYuI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyInI"] != null && dt.Rows[i]["QtyInI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyInI"]) != 0)   //
                    {
                        dt.Rows[i]["QtyInI"] = Convert.ToDouble(dt.Rows[i]["QtyInI"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyInI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyNow"] != null && dt.Rows[i]["QtyNow"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyNow"]) != 0)   //
                    {
                        dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["QtyNow"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyNow"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["iTaxPrice"] != null && dt.Rows[i]["iTaxPrice"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iTaxPrice"]) != 0)   //
                    {
                        dt.Rows[i]["iTaxPrice"] = Convert.ToDouble(dt.Rows[i]["iTaxPrice"]);
                    }
                    else
                    {
                        dt.Rows[i]["iTaxPrice"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iTaxRate"] != null && dt.Rows[i]["iTaxRate"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iTaxRate"]) != 0)   //
                    {
                        dt.Rows[i]["iTaxRate"] = Convert.ToDouble(dt.Rows[i]["iTaxRate"]);
                    }
                    else
                    {
                        dt.Rows[i]["iTaxRate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["ʹ������"] != null && dt.Rows[i]["ʹ������"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["ʹ������"]) != 0)   //
                    {
                        dt.Rows[i]["ʹ������"] = Convert.ToDouble(dt.Rows[i]["ʹ������"]);
                    }
                    else
                    {
                        dt.Rows[i]["ʹ������"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["����ʹ������"] != null && dt.Rows[i]["����ʹ������"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["����ʹ������"]) != 0)   //
                    {
                        dt.Rows[i]["����ʹ������"] = Convert.ToDouble(dt.Rows[i]["����ʹ������"]);
                    }
                    else
                    {
                        dt.Rows[i]["����ʹ������"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iQuantityI"] != null && dt.Rows[i]["iQuantityI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iQuantityI"]) != 0)   //
                    {
                        dt.Rows[i]["iQuantityI"] = Convert.ToDouble(dt.Rows[i]["iQuantityI"]);
                    }
                    else
                    {
                        dt.Rows[i]["iQuantityI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CurrQtyI"] != null && dt.Rows[i]["CurrQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CurrQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["CurrQtyI"] = Convert.ToDouble(dt.Rows[i]["CurrQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["CurrQtyI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CurrNumI"] != null && dt.Rows[i]["CurrNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CurrNumI"]) != 0)   //
                    {
                        dt.Rows[i]["CurrNumI"] = Convert.ToDouble(dt.Rows[i]["CurrNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["CurrNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["POQtyI"] != null && dt.Rows[i]["POQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["POQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["POQtyI"] = Convert.ToDouble(dt.Rows[i]["POQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["POQtyI"] = DBNull.Value;
                        dt.Rows[i]["PODate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["PONumI"] != null && dt.Rows[i]["PONumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["PONumI"]) != 0)   //
                    {
                        dt.Rows[i]["PONumI"] = Convert.ToDouble(dt.Rows[i]["PONumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["PONumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["OMQtyI"] != null && dt.Rows[i]["OMQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["OMQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["OMQtyI"] = Convert.ToDouble(dt.Rows[i]["OMQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["OMQtyI"] = DBNull.Value;
                        dt.Rows[i]["OMDate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["OMNumI"] != null && dt.Rows[i]["OMNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["OMNumI"]) != 0)   //
                    {
                        dt.Rows[i]["OMNumI"] = Convert.ToDouble(dt.Rows[i]["OMNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["OMNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkQtyI"] != null && dt.Rows[i]["WorkQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["WorkQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["WorkQtyI"] = Convert.ToDouble(dt.Rows[i]["WorkQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkQtyI"] = DBNull.Value;
                        dt.Rows[i]["WorkDate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkNumI"] != null && dt.Rows[i]["WorkNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["WorkNumI"]) != 0)   //
                    {
                        dt.Rows[i]["WorkNumI"] = Convert.ToDouble(dt.Rows[i]["WorkNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkNumI"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["CanUseQty"] != null && dt.Rows[i]["CanUseQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CanUseQty"]) != 0)   //
                    {
                        dt.Rows[i]["CanUseQty"] = Convert.ToDouble(dt.Rows[i]["CanUseQty"]);
                    }
                    else
                    {
                        dt.Rows[i]["CanUseQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CanUseNum"] != null && dt.Rows[i]["CanUseNum"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CanUseNum"]) != 0)   //
                    {
                        dt.Rows[i]["CanUseNum"] = Convert.ToDouble(dt.Rows[i]["CanUseNum"]);
                    }
                    else
                    {
                        dt.Rows[i]["CanUseNum"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkDate2"] != null && dt.Rows[i]["WorkDate2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[i]["WorkDate2"]) != DateTime.Parse("1900-01-01"))   //
                    {
                        dt.Rows[i]["WorkDate2"] = Convert.ToDateTime(dt.Rows[i]["WorkDate2"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkDate2"] = DBNull.Value;
                    }
                    #endregion

                    DateTime daa1 = Convert.ToDateTime(dt.Rows[i]["Date1"]);
                    DateTime daa2 = Convert.ToDateTime(dt.Rows[i]["Date2"]);

                    TimeSpan tss = daa2 - daa1;
                    int iDay = tss.Days + 1;

                    int i�������� = ReturnObjectToInt(dt.Rows[i]["��������"]);
                    dt.Rows[i]["�ƻ�����"] = iDay;
                    if (iDay < i��������)
                    {
                        dt.Rows[i]["��������ѹ��"] = iDay;
                    }
                }

                DataView dv = dt.DefaultView;
                string sSQL2 = " 1=1 ";

                if (chkDateNeed.Checked)
                {
                    sSQL2 = sSQL2 + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    sSQL2 = sSQL2 + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
                }
                if (lookUpEditSOCode.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
                }
                if (lookUpEditiRow1.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
                }
                if (lookUpEditiRow2.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
                }
                if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
                }
                if (lookUpEditVenDep.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
                }
                if (lookUpEditEnSure.Text.Trim() == "����")
                {
                    sSQL2 = sSQL2 + " and (WorkDateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = '����') ";
                }
                if (lookUpEditEnSure.Text.Trim() == "�ɹ�")
                {
                    sSQL2 = sSQL2 + " and  (PODateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = '�ɹ�') ";
                }
                if (lookUpEditEnSure.Text.Trim() == "ί��")
                {
                    sSQL2 = sSQL2 + " and (OMDateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = 'ί��') ";
                }
                //if (radio1.Checked)
                //{
                //    sSQL2 = sSQL2 + " and isnull(bCreateDayPlan,0) = 0 ";
                //}
                //if (radio2.Checked)
                //{
                //    sSQL2 = sSQL2 + " and isnull(bCreateDayPlan,0) = 1 ";
                //}

                dv.RowFilter = sSQL2;
                dtOMPlanDay = dv.ToTable();

                gridControl1.DataSource = dtOMPlanDay;

                if (radio1.Checked)
                {
                    radio1_CheckedChanged(null, null);
                }
                if (radio2.Checked)
                {
                    radio2_CheckedChanged(null, null);
                }
                if (radio3.Checked)
                {
                    radio3_CheckedChanged(null, null);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("���ί��ƻ���Ϣʧ�ܣ�\n    " + ee.Message);
            }
        }

        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnFirst()
        {
            string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");


            //���ί���ռƻ�����
            string sSQL = "select * from UFDLImport.dbo.OMPlanDay where 1=-1";
            DataTable dtOMPlanDay = clsSQLCommond.ExecQuery(sSQL);
            DataRow drOMPlanDay = null;
            string sMsg = "    ";
            ArrayList aLRow = new ArrayList();

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }


            sSQL = "select GETDATE()";
            DateTime d��ǰʱ�� = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                    continue;

                if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                {
                    sMsg = sMsg + "��" + (i + 1) + "δ���ù�Ӧ��\n";
                    continue;
                }

              
                if (gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim() == "")
                {
                    sMsg = sMsg + "��" + (i + 1) + "δ���üƻ�����\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim() == "")
                {
                    sMsg = sMsg + "��" + (i + 1) + "δ���������������\n";
                    continue;
                }
                //if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() == "")
                //{
                //    sMsg = sMsg + "��" + (i + 1) + "δ���õ���\n";
                //    continue;
                //}
                if (gridView1.GetRowCellValue(i, gridColEnSureUser).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColiType).ToString().Trim() == "��")
                {
                    sMsg = sMsg + "�� " + (i + 1) + " ��Ҫȷ�ϲ��ܱ��� \n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() == "")
                {
                    sMsg = sMsg + "�� " + (i + 1) + " û����ЧBOM����˲� \n";
                    continue;
                }

                if (ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6) <= 0)
                {
                    string sInvCode = gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim();
                    string sVen = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();

                    DataTable dtPrice = GetVendPriceInfo(sInvCode, sVen);
                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(i, gridColiTaxPrice, dtPrice.Rows[0]["iTaxPrice"]);
                        gridView1.SetRowCellValue(i, gridColiTaxRate, dtPrice.Rows[0]["iTaxRate"]);
                    }

                    if (ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6) <= 0)
                    {
                        sMsg = sMsg + "��" + (i + 1) + "δ���õ���\n";
                        continue;
                    }
                }

                drOMPlanDay = dtOMPlanDay.NewRow();
                drOMPlanDay["cCode"] = sCode;
                drOMPlanDay["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                drOMPlanDay["Soid"] = gridView1.GetRowCellValue(i, gridColSoid).ToString().Trim();
                drOMPlanDay["Sodid"] = gridView1.GetRowCellValue(i, gridColSoDid).ToString().Trim();
                drOMPlanDay["SoCode"] = gridView1.GetRowCellValue(i, gridColSoCode).ToString().Trim();
                drOMPlanDay["SoSeq"] = gridView1.GetRowCellValue(i, gridColSoSeq).ToString().Trim();
                drOMPlanDay["PlanCode"] = gridView1.GetRowCellValue(i, gridColPlanCode).ToString().Trim();
                drOMPlanDay["InvCode"] = gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim();
                drOMPlanDay["InvName"] = gridView1.GetRowCellValue(i, gridColInvName).ToString().Trim();
                drOMPlanDay["InvStd"] = gridView1.GetRowCellValue(i, gridColInvStd).ToString().Trim();
                drOMPlanDay["ComUnitCode"] = gridView1.GetRowCellValue(i, gridColComUnitCode).ToString().Trim();
                drOMPlanDay["ComUnitName"] = gridView1.GetRowCellValue(i, gridColComUnitName).ToString().Trim();
                drOMPlanDay["PlanQty"] = gridView1.GetRowCellValue(i, gridColPlanQty).ToString().Trim();
                drOMPlanDay["QtyNow"] = gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim();
                drOMPlanDay["StartDate2"] = gridView1.GetRowCellValue(i, gridColStartDate2).ToString().Trim();
                drOMPlanDay["DueDate2"] = gridView1.GetRowCellValue(i, gridColDueDate2).ToString().Trim();
                drOMPlanDay["cVenCode"] = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                drOMPlanDay["cVenName"] = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() != "")
                    drOMPlanDay["iTaxPrice"] = gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim() != "")
                    drOMPlanDay["iTaxRate"] = gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim();
                drOMPlanDay["Accid"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                drOMPlanDay["AccYear"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                drOMPlanDay["cAssComUnitCode"] = gridView1.GetRowCellValue(i, gridColComUnitCode).ToString().Trim();
                drOMPlanDay["CompScrap"] = gridView1.GetRowCellValue(i, gridColCompScrap).ToString().Trim();
                drOMPlanDay["BaseQtyD"] = gridView1.GetRowCellValue(i, gridColBaseQtyD).ToString().Trim();
                drOMPlanDay["BaseQtyN"] = gridView1.GetRowCellValue(i, gridColBaseQtyN).ToString().Trim();
                drOMPlanDay["bomID"] = gridView1.GetRowCellValue(i, gridColbomID).ToString().Trim();
                drOMPlanDay["cDefWareHouse"] = gridView1.GetRowCellValue(i, gridColcDefWareHouse).ToString().Trim();
                drOMPlanDay["ParentScrap"] = gridView1.GetRowCellValue(i, gridColParentScrap).ToString().Trim();
                drOMPlanDay["cInvCode"] = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                drOMPlanDay["cInvName"] = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                drOMPlanDay["cInvStd"] = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                drOMPlanDay["iSupplyType"] = gridView1.GetRowCellValue(i, gridColiSupplyType).ToString().Trim();
                drOMPlanDay["OpComponentid"] = gridView1.GetRowCellValue(i, gridColOpComponentid).ToString().Trim();
                drOMPlanDay["ʹ������"] = gridView1.GetRowCellValue(i, gridColʹ������);
                drOMPlanDay["����ʹ������"] = gridView1.GetRowCellValue(i, gridCol����ʹ������);
                if (gridView1.GetRowCellValue(i, gridColChangeRate).ToString().Trim() == "")
                    drOMPlanDay["ChangeRate"] = DBNull.Value;
                else
                    drOMPlanDay["ChangeRate"] = gridView1.GetRowCellValue(i, gridColChangeRate).ToString().Trim();
                //drOMPlanDay["UseQty"] = gridView1.GetRowCellValue(i,       ).ToString().Trim();
                //drOMPlanDay["UseNum"] = gridView1.GetRowCellValue(i,       ).ToString().Trim();
                drOMPlanDay["cComUnitCodeI"] = gridView1.GetRowCellValue(i, gridColcComUnitCodeI).ToString().Trim();
                drOMPlanDay["cAssComUnitCodeI"] = gridView1.GetRowCellValue(i, gridColcAssComUnitCodeI).ToString().Trim();
                drOMPlanDay["unitCode1"] = gridView1.GetRowCellValue(i, gridColunitCode1).ToString().Trim();
                drOMPlanDay["unitCode2"] = gridView1.GetRowCellValue(i, gridColunitCode2).ToString().Trim();
                drOMPlanDay["iQuantityI"] = gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim();
                drOMPlanDay["date1"] = gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim();
                drOMPlanDay["date2"] = gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim();
                drOMPlanDay["invSM"] = gridView1.GetRowCellValue(i, gridColinvSM).ToString().Trim();
                drOMPlanDay["invSZ"] = gridView1.GetRowCellValue(i, gridColinvSZ).ToString().Trim();
                drOMPlanDay["iType"] = gridView1.GetRowCellValue(i, gridColiType);
                drOMPlanDay["ImportDate"] = d��ǰʱ��;
                drOMPlanDay["cDepCode"] = gridView1.GetRowCellValue(i, gridColcDepCode);
                if (gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim() == "")
                {
                    drOMPlanDay["iNumI"] = DBNull.Value;
                }
                else
                {
                    drOMPlanDay["iNumI"] = gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim();
                }
                drOMPlanDay["bUse"] = "true";

                dtOMPlanDay.Rows.Add(drOMPlanDay);

                aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
            }

            if (sMsg.Trim() != "")
            {
                throw new Exception(sMsg.Trim());
            }

            ArrayList aList = new ArrayList();
            if (dtOMPlanDay != null && dtOMPlanDay.Rows.Count > 0)
            {

                for (int i = 0; i < dtOMPlanDay.Rows.Count; i++)
                {
                    //ɾ���Ѿ�������iid
                    string sSQL2 = "delete UFDLImport..OMPlanDay where cCode like '" + dtOMPlanDay.Rows[i]["cCode"].ToString().Trim() + "%' and iID = " + dtOMPlanDay.Rows[i]["iID"].ToString().Trim();
                    aList.Add(sSQL2);
                }
                for (int i = 0; i < dtOMPlanDay.Rows.Count; i++)
                {
                    //����ί���ռƻ�
                    aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "OMPlanDay", dtOMPlanDay, i));
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("�����ռƻ��ɹ���");
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = 0; i < aLRow.Count; i++)
                {
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(j, gridColiID).ToString().Trim() == aLRow[i].ToString().Trim())
                        {
                            gridView1.SetRowCellValue(j, gridColbCreateDayPlan, 1);
                        }
                    }
                }
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
            }
            else
            {
                throw new Exception("û��ѡ����Ҫ�����ռƻ�������");
            }
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnPrev()
        {
            dtOMPlanDay = new DataTable();

            chkAll.Checked = false;

            int iCou = -1;
            if (radio1to1.Checked)
            {
                iCou = 1;
            }
            if (radio1toN.Checked)
            {
                iCou = 2;
            }
            if (radioAll.Checked)
            {
                iCou = 0;
            }
            if (iCou == -1)
                throw new Exception("ȡ������");

            string sSQL = "exec @u8._Getί���ռƻ���ѯ '200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'," + iCou + ",'" + datePlan.DateTime.ToString("yyMMdd") + "'";
            sSQL = sSQL + ";select cast(0 as bit) as ѡ��, * from @u8.TH_OMPlan_1 ";

            sSQL = sSQL + " where 1=1 ";
            if (!chkAllInfo.Checked)
            {
                sSQL = sSQL + " and isnull(iSendT,0) < isnull(PlanQty,0) ";
            }

            if (chkDateNeed.Checked)
            {
                sSQL = sSQL + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            else
            {
                sSQL = sSQL + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
            }
            if (lookUpEditSOCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
            }
            if (lookUpEditiRow1.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
            }
            if (lookUpEditiRow2.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
            }
            if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
            }
            if (lookUpEditVenDep.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "����")
            {
                sSQL = sSQL + " and EnSureDepment = '����' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "�ɹ�")
            {
                sSQL = sSQL + " and EnSureDepment = '�ɹ�' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "ί��")
            {
                sSQL = sSQL + " and EnSureDepment = 'ί��' ";
            }

            sSQL = sSQL + " order by date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["RemarkXB"].ToString().Trim() == "")
                {
                    dt.Rows[i]["RemarkXB"] = "��";
                }
            }

            DataView dvTemp = dt.DefaultView;

            if (radio1to1.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            }
            if (radio1toN.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }
            if (radioAll.Checked)
            {

                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }

            DataTable dtTemp = dvTemp.ToTable().Copy();
            gridControl1.DataSource = dtTemp;

            GetQty();

            dt = (DataTable)gridControl1.DataSource;

            DataView dv = dt.DefaultView;
            string sRowFilter = " 1=1 ";
            if (!chkCurrQty.Checked)
            {
                string siID = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["iQtyCanOut"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[i]["iQtyCanOut"]) == 0)
                    {
                        if (siID.Trim() == string.Empty)
                        {
                            siID = "'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            siID = siID + ",'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                    }
                }
                if (siID != "")
                {
                    sRowFilter = sRowFilter + " and iID not in (" + siID + ") ";
                }
            }
            dv.RowFilter = sRowFilter;
            dtOMPlanDay = dv.ToTable().Copy();
            gridControl1.DataSource = dtOMPlanDay;

        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        private void btnNext()
        {
            try
            {

            }
            catch { }
        }

        /// <summary>
        /// ĩҳ
        /// </summary>
        private void btnLast()
        {
            try
            {

            }
            catch { }
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnAddRow()
        {
            gridView1.AddNewRow();
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        private void btnDelRow()
        {
            //for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    sSQL = "delete UFDLImport..OMPlanDay where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and AccID = '200' and Accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
                    aList.Add(sSQL);
                    
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("ɾ�гɹ���");
                btnLoad();
            }
        }
        /// <summary>
        /// �޸�
        /// </summary>
        private void btnEdit()
        {

        }
        /// <summary>
        /// ɾ��
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// ����
        /// </summary>

        private void btnSave()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    if (gridView1.GetRowCellValue(i, gridColEnSureUser).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColiType).ToString().Trim() == "3")
                    {
                        sErr = sErr + "�� " + (i + 1) + " �ƻ�������Դ�������ݣ���Ҫȷ�ϲ��ܱ��� \n";
                        continue;
                    }

                    string sNumI = gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim();
                    if (sNumI == "" || sNumI == "0")
                    {
                        sNumI = "null";
                    }

                    decimal dPrice = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6);
                    if (dPrice <= 0)
                    {
                        sErr = sErr + "�� " + (i + 1) + "  ���۲���ȷ\n";
                        continue;
                    }

                    string sPrice = gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim();
                    if (sPrice == "" || sPrice == "0")
                    {
                        sPrice = "null";
                    }
                    string sTaxRate = gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim();
                    if (sTaxRate == "" || sTaxRate == "0")
                    {
                        sTaxRate = "null";
                    }
                    sSQL = "update UFDLImport..OMPlanDay set qtynow = " + gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim() + ",date1 = '" + gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim() + "',date2 = '" + gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim() + "'," +
                                "cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "',cVenName = '" + gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() + "'," +
                                "iTaxPrice = " + sPrice + ",iTaxRate=" + sTaxRate + ",iQuantityI = " + gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim() + ",iNumI = " + sNumI + " " +
                           " where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "����ʧ��";
                fMsgBos.richTextBox1.Text = "����ʧ�ܣ�ԭ�����£�\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("����ɹ���");
            }
        }


        /// <summary>
        /// ����
        /// </summary>
        private void btnUnDo()
        {
        }
        /// <summary>
        /// ���
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// ����
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// ��
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// �ر�
        /// </summary>
        private void btnClose()
        {

        }

        /// <summary>
        /// ���
        /// </summary>
        private void btnAlter()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                string sSQL = "select GETDATE()";
                string s��ǰʱ�� = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();

                DataTable dtView = ((DataTable)gridControl1.DataSource).Copy();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "һ�Զ�����";
                dc.DefaultValue = 0;
                dtView.Columns.Add(dc);

                for (int i = 0; i < dtView.Rows.Count; i++)
                {
                    int iCou = 0;
                    string siID = dtView.Rows[i]["iID"].ToString().Trim();
                    for (int j = i; j < dtView.Rows.Count; j++)
                    {
                        if (siID == dtView.Rows[j]["iID"].ToString().Trim())
                        {
                            iCou = iCou + 1;
                        }
                    }
                    if (iCou > 1)
                    {
                        for (int j = i; j < dtView.Rows.Count; j++)
                        {
                            if (siID == dtView.Rows[j]["iID"].ToString().Trim())
                            {
                                dtView.Rows[j]["һ�Զ�����"] = 1;
                            }
                        }
                    }
                }

                DataView dv = dtView.DefaultView;
                dv.RowFilter = " һ�Զ����� <> '0' and ѡ�� = true ";
                dv.Sort = " �Ӽ���λ,cInvCode asc,RemarkXB";
                DataTable dt = dv.ToTable();
                int iRow = 0;
                decimal d�Ӽ��������� = 0;
                if (dt.Rows.Count > 0)
                {
                    RepOMPlanDay rep = new RepOMPlanDay();
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string siID = dt.Rows[i]["iID"].ToString().Trim();
                        if (Convert.ToBoolean( dt.Rows[i]["ѡ��"].ToString().Trim()))
                        {
                            bool bPrint = false;
                            for (int j = 0; j < i; j++)
                            {
                                if (siID == dt.Rows[j]["iID"].ToString().Trim())
                                {
                                    bPrint = true;
                                    break;
                                }
                            }
                            if (bPrint)
                            {
                                continue;
                            }
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column1"] = dt.Rows[i]["InvCode"];
                            dr["Column2"] = dt.Rows[i]["InvName"];
                            dr["Column3"] = dt.Rows[i]["InvStd"];
                            dr["Column4"] = dt.Rows[i]["comUnitName"];
                            dr["Column5"] = decimal.Round(Convert.ToDecimal(dt.Rows[i]["PlanQty"]), 0);
                            dr["Column11"] = decimal.Round(Convert.ToDecimal(dt.Rows[i]["QtyNow"]), 0);
                            dr["Column6"] = dt.Rows[i]["cVenCode"] + " -- " + dt.Rows[i]["cVenName"];
                            if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                            {
                                dr["Column7"] = Convert.ToDateTime(dt.Rows[i]["date2"]).ToString("yy-MM-dd");
                            }
                            dr["Column9"] = dt.Rows[i]["id"];
                            dr["Column10"] = dt.Rows[i]["SoCode"] + " -- " + dt.Rows[i]["SoSeq"];
                            dr["Column12"] = iRow;
                            dr["Column13"] = dt.Rows[i]["RemarkXB"];
                            dr["Column17"] = dt.Rows[i]["cInvName"];
                            dr["Column20"] = sUserName;


                            d�Ӽ��������� = d�Ӽ��������� + Convert.ToDecimal(dr["Column11"]);

                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("��ѡ����Ҫ��ӡ�����ݣ�");
                        return;
                    }
                    #region �ǼǴ�ӡ

                    long iջ��1 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��1.Text.Trim());
                    long iջ��2 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��2.Text.Trim());
                    long iջ��3 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��3.Text.Trim());
                    long iջ��4 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��4.Text.Trim());
                    long iջ��5 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��5.Text.Trim());
                    long iջ��6 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��6.Text.Trim());
                    long iջ��7 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��7.Text.Trim());
                    long iջ��8 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��8.Text.Trim());
                    long iջ��9 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��9.Text.Trim());
                    long iջ��10 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��10.Text.Trim());

                    string sGuid = Guid.NewGuid().ToString();
                    sSQL = "insert into UFDLImport..ջ���ӡ�Ǽ�(GUID, ��������,  ջ��1, ջ��2, ջ��3, ջ��4, ջ��5, ջ��6, ջ��7, ջ��8, ջ��9, ջ��10,����)" +
                        "values('" + sGuid + "','ί���ռƻ�����'," + iջ��1 + "," + iջ��2 + "," + iջ��3 + "," + iջ��4 + "," + iջ��5 + "," + iջ��6 + "," + iջ��7 + "," + iջ��8 + "," + iջ��9 + "," + iջ��10 + "," + dtDetail.Rows.Count + ")";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = "select * from UFDLImport..ջ���ӡ�Ǽ� where GUID = '" + sGuid + "'";
                    DataTable dtջ���ӡ�Ǽ� = clsSQLCommond.ExecQuery(sSQL);
                    string sIDջ���ӡ�Ǽ� = "";
                    if (dtջ���ӡ�Ǽ� != null && dtջ���ӡ�Ǽ�.Rows.Count > 0)
                        sIDջ���ӡ�Ǽ� = dtջ���ӡ�Ǽ�.Rows[0]["iID"].ToString().Trim();

                    #endregion

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "�ƻ����ڣ�" + datePlan.DateTime.ToString("yy-MM-dd");
                    if (txtVenName.Text.Trim() != "" && txtVenCode.Text.Trim() != "")
                    {
                        dRowTe["Column2"] = "��Ӧ�̣�" + txtVenCode.Text.Trim() + " -- " + txtVenName.Text.Trim();
                    }
                    else
                    {
                        dRowTe["Column2"] = "";
                    }


                    dRowTe["Column4"] = d�Ӽ���������;
                    dRowTe["Column5"] = s��ǰʱ��;
                    dRowTe["Column12"] = sIDջ���ӡ�Ǽ�;

                    string sջ�� = "";
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��1.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��1.Text + "[  " + txtջ��1.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��2.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��2.Text + "[  " + txtջ��2.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��3.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��3.Text + "[  " + txtջ��3.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��4.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��4.Text + "[  " + txtջ��4.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��5.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��5.Text + "[  " + txtջ��5.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��6.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��6.Text + "[  " + txtջ��6.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��7.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��7.Text + "[  " + txtջ��7.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��8.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��8.Text + "[  " + txtջ��8.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��9.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��9.Text + "[  " + txtջ��9.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��10.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��10.Text + "[  " + txtջ��10.Text.Trim() + "  ]  ";
                    }
                    dRowTe["Column11"] = sջ��;
                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                    dt = null;
                }
                dv.RowFilter = " һ�Զ����� = '0' and ѡ�� = true ";
                dv.Sort = "�Ӽ���λ,cInvCode asc ,RemarkXB";
                DataTable dt2 = dv.ToTable();

                iRow = 0;
                d�Ӽ��������� = 0;
                if (dt2.Rows.Count > 0)
                {
                    RepOMPlanDay2 rep = new RepOMPlanDay2();
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        string siID = dt2.Rows[i]["iID"].ToString().Trim();
                        string sID = dt2.Rows[i]["ID"].ToString().Trim();
                        if (Convert.ToBoolean( dt2.Rows[i]["ѡ��"].ToString().Trim() ))
                        {
                            bool bPrint = false;
                            for (int j = 0; j < i; j++)
                            {
                                if (siID == dt2.Rows[j]["iID"].ToString().Trim())
                                {
                                    bPrint = true;
                                    break;
                                }
                            }
                            if (bPrint)
                            {
                                continue;
                            }
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column12"] = iRow;
                            dr["Column10"] = dt2.Rows[i]["cInvCode"];
                            dr["Column1"] = dt2.Rows[i]["cInvStd"];
                            if (dt2.Rows[i]["CurrQtyI"] != null && dt2.Rows[i]["CurrQtyI"].ToString().Trim() != "")
                            {
                                dr["Column2"] = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["CurrQtyI"]), 0);
                            }
                            dr["Column3"] = dt2.Rows[i]["SoCode"] + " -- " + dt2.Rows[i]["SoSeq"];
                            dr["Column4"] = dt2.Rows[i]["InvCode"];
                            dr["Column5"] = dt2.Rows[i]["InvName"];
                            if (dt2.Rows[i]["date2"] != null && dt2.Rows[i]["date2"].ToString().Trim() != "")
                            {
                                dr["Column6"] = Convert.ToDateTime(dt2.Rows[i]["date2"]).ToString("yyyy-MM-dd");
                            }
                            if (dt2.Rows[i]["date1"] != null && dt2.Rows[i]["date1"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt2.Rows[i]["date1"]).ToString("yyyy-MM-dd");
                            }
                            //dr["Column7"] = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["QtyNow"]), 0);
                            if (dt2.Rows[i]["CurrQtyI"] != null && dt2.Rows[i]["CurrQtyI"].ToString().Trim() != "" && dt2.Rows[i]["iQtyCanOut"] != null && dt2.Rows[i]["iQtyCanOut"].ToString().Trim() != "")
                            {
                                decimal d���ο����� = decimal.Round((decimal.Round(Convert.ToDecimal(dt2.Rows[i]["iQtyCanOut"]), 6) / decimal.Round(Convert.ToDecimal(dt2.Rows[i]["ʹ������"]), 6)), 0);
                                decimal d�������� = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["QtyNow"]), 6);
                                if (d���ο����� > d��������)
                                {
                                    dr["Column7"] = d��������;
                                    dr["Column8"] = decimal.Round(d�������� * decimal.Round(Convert.ToDecimal(dt2.Rows[i]["ʹ������"]), 6), 6);
                                }
                                else
                                {
                                    dr["Column7"] = d���ο�����;
                                    dr["Column8"] = decimal.Round(d���ο����� * decimal.Round(Convert.ToDecimal(dt2.Rows[i]["ʹ������"]), 6), 6);
                                }


                                if (dt2.Rows[i]["ChangeRate"] != null && dt2.Rows[i]["ChangeRate"].ToString().Trim() != "")
                                {
                                    decimal d = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["ChangeRate"]), 6);
                                    dr["Column14"] = decimal.Round(decimal.Round(Convert.ToDecimal(dt2.Rows[i]["iQtyCanOut"]), 6) / d, 6);
                                }
                            }
                            dr["Column13"] = dt2.Rows[i]["cVenCode"] + " -- " + dt2.Rows[i]["cVenName"];
                            if (dt2.Rows[i]["iQtyCanOut"] == null || dt2.Rows[i]["iQtyCanOut"].ToString().Trim() == "")
                            {
                                dr["Column9"] = dt2.Rows[i]["id"] + "-" + 0;
                            }
                            else
                            {
                                dr["Column9"] = dt2.Rows[i]["id"] + "-" + decimal.Round(Convert.ToDecimal(dr["Column8"]), 6);
                            }
                            dr["Column15"] = dt2.Rows[i]["RemarkXB"];
                            dr["Column16"] = dt2.Rows[i]["�Ӽ���λ"];
                            dr["Column17"] = dt2.Rows[i]["cInvName"];
                            dr["Column20"] = sUserName;


                            d�Ӽ��������� = d�Ӽ��������� + Convert.ToDecimal(dr["Column7"]);


                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("��ѡ����Ҫ��ӡ�����ݣ�");
                        return;
                    }

                    #region �ǼǴ�ӡ

                    long iջ��1 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��1.Text.Trim());
                    long iջ��2 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��2.Text.Trim());
                    long iջ��3 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��3.Text.Trim());
                    long iջ��4 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��4.Text.Trim());
                    long iջ��5 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��5.Text.Trim());
                    long iջ��6 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��6.Text.Trim());
                    long iջ��7 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��7.Text.Trim());
                    long iջ��8 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��8.Text.Trim());
                    long iջ��9 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��9.Text.Trim());
                    long iջ��10 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��10.Text.Trim());

                    string sGuid = Guid.NewGuid().ToString();
                    sSQL = "insert into UFDLImport..ջ���ӡ�Ǽ�(GUID, ��������,  ջ��1, ջ��2, ջ��3, ջ��4, ջ��5, ջ��6, ջ��7, ջ��8, ջ��9, ջ��10,����)" +
                        "values('" + sGuid + "','ί���ռƻ�����'," + iջ��1 + "," + iջ��2 + "," + iջ��3 + "," + iջ��4 + "," + iջ��5 + "," + iջ��6 + "," + iջ��7 + "," + iջ��8 + "," + iջ��9 + "," + iջ��10 + "," + dtDetail.Rows.Count + ")";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = "select * from UFDLImport..ջ���ӡ�Ǽ� where GUID = '" + sGuid + "'";
                    DataTable dtջ���ӡ�Ǽ� = clsSQLCommond.ExecQuery(sSQL);
                    string sIDջ���ӡ�Ǽ� = "";
                    if (dtջ���ӡ�Ǽ� != null && dtջ���ӡ�Ǽ�.Rows.Count > 0)
                        sIDջ���ӡ�Ǽ� = dtջ���ӡ�Ǽ�.Rows[0]["iID"].ToString().Trim();

                    #endregion

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "�ƻ����ڣ�" + datePlan.DateTime.ToString("yyyy-MM-dd");
                    if (txtVenName.Text.Trim() != "" && txtVenCode.Text.Trim() != "")
                    {
                        dRowTe["Column2"] = "��Ӧ�̣�" + txtVenCode.Text.Trim() + " -- " + txtVenName.Text.Trim();
                    }
                    else
                    {
                        dRowTe["Column2"] = "";
                    }
                    dRowTe["Column3"] = dtDetail.Rows.Count;
                    dRowTe["Column4"] = d�Ӽ���������;
                    dRowTe["Column5"] = s��ǰʱ��;

                    string sջ�� = "";
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��1.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��1.Text + "[  " + txtջ��1.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��1.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��2.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��2.Text + "[  " + txtջ��2.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��2.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��3.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��3.Text + "[  " + txtջ��3.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��3.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��4.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��4.Text + "[  " + txtջ��4.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��4.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��5.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��5.Text + "[  " + txtջ��5.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��5.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��6.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��6.Text + "[  " + txtջ��6.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��6.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��7.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��7.Text + "[  " + txtջ��7.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��7.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��8.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��8.Text + "[  " + txtջ��8.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��8.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��9.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��9.Text + "[  " + txtջ��9.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��9.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txtջ��10.Text.Trim()) > 0)
                    {
                        sջ�� = sջ�� + labelջ��10.Text + "[  " + txtջ��10.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        sջ�� = sջ�� + labelջ��10.Text + "[            ]  ";
                    }
                    dRowTe["Column11"] = sջ��;

                    dRowTe["Column12"] = sIDջ���ӡ�Ǽ�;

                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش�ӡʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private new void SetBtnEnable(bool b)
        {
            //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
            //{
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "createdayplan")
            //    {
            //        base.toolStrip1.Items[i].Enabled = b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "print")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "delrow")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "save")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //}
            //btnEnSure.Enabled = b;
            //btnUnEnSure.Enabled = b;
        }

        //protected override void BtnClick(string sBtnName, string sBtnText)
        //{
        //    try
        //    {
        //        switch (sBtnName.ToLower())
        //        {
        //            case "get":
        //                btnGet();
        //                bBtnType = false;
        //                SetBtnEnable(true);
        //                SetColEnable(true);
        //                bGetOrLoad = true;
        //                break;
        //            case "createdayplan":
        //                btnCreateDayPlan();
        //                break;
        //            case "load":
        //                btnLoad();
        //                bBtnType = true;
        //                SetBtnEnable(false);
        //                SetColEnable(true);
        //                bGetOrLoad = false;
        //                break;
        //            case "delrow":
        //                btnDelRow();
        //                break;
        //            case "save":
        //                btnSave();
        //                break;
        //            case "print":
        //                btnPrint();
        //                break;
        //            case "export":
        //                btnExport();
        //                break;
        //            case "close":
        //                btnClosed();
        //                break;
        //            default:
        //                MessageBox.Show("�ù�����δ�ṩ���������Ա��ѯ��");
        //                break;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnClosed()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    sSQL = "update UFDLImport..OMPlan set bClosed=1,ClosedUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ClosedDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                             " where iID = " + sID;
                    aList.Add(sSQL);
                }
            }

            if (sErr != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "�رռƻ�ʧ��";
                fMsgBos.richTextBox1.Text = "�رռƻ�ʧ�ܣ�ԭ�����£�\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("�رռƻ��ɹ���");
            }
        }


        /// <summary>
        /// ��ǰ�ռƻ�
        /// </summary>
        private void btnLoad()
        {
            dtOMPlanDay = new DataTable();

            chkAll.Checked = false;
  
            int iCou = -1;
            if (radio1to1.Checked)
            {
                iCou = 1;
            }
            if (radio1toN.Checked)
            {
                iCou=2;
            }
            if (radioAll.Checked)
            {
                iCou=0;
            }
            if (iCou == -1)
                throw new Exception("ȡ������");

            string sSQL = "exec @u8._Getί���ռƻ���ѯ '200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'," + iCou + ",'" + datePlan.DateTime.ToString("yyMMdd") + "'";
            sSQL = sSQL + ";select cast(0 as bit) as ѡ��,* from @u8.TH_OMPlan_1 ";

            sSQL = sSQL + " where 1=1 ";
            if (!chkAllInfo.Checked)
            {
                sSQL = sSQL + " and isnull(iSendT,0) < isnull(PlanQty,0) ";
            }

            if (chkDateNeed.Checked)
            {
                sSQL = sSQL + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            else
            {
                sSQL = sSQL + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
            }
            if (lookUpEditSOCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
            }
            if (lookUpEditiRow1.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
            }
            if (lookUpEditiRow2.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
            }
            if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
            }
            if (lookUpEditVenDep.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "����")
            {
                sSQL = sSQL + " and EnSureDepment = '����' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "�ɹ�")
            {
                sSQL = sSQL + " and EnSureDepment = '�ɹ�' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "ί��")
            {
                sSQL = sSQL + " and EnSureDepment = 'ί��' ";
            }

            sSQL = sSQL + " order by date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["RemarkXB"].ToString().Trim() == "")
                {
                    dt.Rows[i]["RemarkXB"] = "��";
                }
            }

            DataView dvTemp = dt.DefaultView;

            if (radio1to1.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            }
            if (radio1toN.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }
            if (radioAll.Checked)
            {

                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }

            gridControl1.DataSource = dvTemp.ToTable().Copy();

            GetQty();

            dt = (DataTable)gridControl1.DataSource;

            DataView dv = dt.DefaultView;
            string sRowFilter = " 1=1 ";
            if (!chkCurrQty.Checked)
            {
                string siID = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["iQtyCanOut"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[i]["iQtyCanOut"]) == 0)
                    {
                        if (siID.Trim() == string.Empty)
                        {
                            siID = "'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            siID = siID + ",'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                    }
                }
                if (siID != "")
                {
                    sRowFilter = sRowFilter + " and iID not in (" + siID + ") ";
                }
            }
            dv.RowFilter = sRowFilter;
            dtOMPlanDay = dv.ToTable().Copy();
            gridControl1.DataSource = dtOMPlanDay;
        }



        private void FrmOMPlanDay_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by iOrder";
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


                GetDepInfo();
                GetlookUpEditEnSure();
 
                GetSoCode();
                dateEdit1.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dateEdit2.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddDays(3).ToString("yyyy-MM-dd");

                dateNeed.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dateEnd.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                datePlan.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                 
                GetWareHouse();

                btnEnSure.Enabled = true;
                btnUnEnSure.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�ԭ��" + ee.Message);
            }
        }

        private void lookUpEditSOCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct cast(SoSeq as varchar(5)) as iID from UFDLImport..OMPlan where SoCode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "' ";
                lookUpEditiRow1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditiRow2.Properties.DataSource = lookUpEditiRow1.Properties.DataSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show("������۶�����ʧ�ܣ�  " + ee.Message);
            }
        }

        private void lookUpEditiRow1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditiRow2.EditValue = lookUpEditiRow1.EditValue;
        }

        private void chkVen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVen.Checked)
            {
                txtVenCode.Text = "";
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
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }
        }

        private void txtcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo fInv = new FrmInvInfo(txtcInvCode.Text.Trim());
            if (DialogResult.OK == fInv.ShowDialog())
            {
                txtcInvCode.Text = fInv.sInvCode;
                txtcInvName.Text = fInv.sInvName;
            }
        }

        private void txtcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetcInvCode(txtcInvCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtcInvName.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtcInvCode.Text = "";
                    txtcInvName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ô����Ϣʧ�ܣ� " + ee.Message);
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
            }
        }

        private DataTable GetcInvCode(string scInvCode)
        {
            try
            {
                string sSQL = "select cInvCode as iID,cInvName as iText from @u8.Inventory  where cInvCode = '" + scInvCode + "' order by cInvCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("��ô����Ϣʧ�ܣ�");
            }
        }

        /// <summary>
        /// ���۶�����
        /// </summary>
        private void GetSoCode()
        {
            try
            {
                string sSQL = "select distinct SoCode as iID from UFDLImport..OMPlan where SoCode is not null order by SoCode";
                lookUpEditSOCode.Properties.DataSource =clsGetSQL.GetLookUpEdit(sSQL);
            }
            catch (Exception ee)
            {
                MessageBox.Show("������۶�����ʧ�ܣ�  " + ee.Message);
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["iID"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["iID"].ToString()))
                e.Handled = true;
        }

        DevExpress.XtraEditors.TextEdit tEditor;
        DevExpress.XtraEditors.ButtonEdit bEditor;
        DevExpress.XtraEditors.DateEdit dEditor;
        DevExpress.XtraEditors.DateEdit dEditor2;

        void CreateMergedEditControl()
        {
            dEditor = new DevExpress.XtraEditors.DateEdit();
            dEditor.Location = new System.Drawing.Point(12, 12);
            dEditor.Name = "dateEdit";
            dEditor.Properties.Appearance.Options.UseTextOptions = true;
            dEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            dEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            dEditor.Properties.AutoHeight = false;
            dEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            dEditor.KeyDown += new KeyEventHandler(dEditor_KeyDown);
            dEditor.Leave += new EventHandler(dEditor_Leave);
        }
        void CreateMerged2EditControl()
        {
            dEditor2 = new DevExpress.XtraEditors.DateEdit();
            dEditor2.Location = new System.Drawing.Point(12, 12);
            dEditor2.Name = "dateEdit2";
            dEditor2.Properties.Appearance.Options.UseTextOptions = true;
            dEditor2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            dEditor2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            dEditor2.Properties.AutoHeight = false;
            dEditor2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            dEditor2.KeyDown += new KeyEventHandler(d2Editor_KeyDown);
            dEditor2.Leave += new EventHandler(dEditor2_Leave);
        }
        //this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
        void CreateMergetEditControl()
        {
            tEditor = new DevExpress.XtraEditors.TextEdit();
            tEditor.Location = new System.Drawing.Point(12, 12);
            tEditor.Name = "txtEdit";
            tEditor.Properties.Appearance.Options.UseTextOptions = true;
            tEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tEditor.Properties.AutoHeight = false;
            tEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            tEditor.KeyDown += new KeyEventHandler(tEditor_KeyDown);
            tEditor.Leave += new EventHandler(tEditor_Leave);
        }
        void CreateMergebEditControl()
        {
            bEditor = new DevExpress.XtraEditors.ButtonEdit();
            bEditor.Location = new System.Drawing.Point(12, 12);
            bEditor.Name = "buttonEdit";
            bEditor.Properties.Appearance.Options.UseTextOptions = true;
            bEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            bEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            bEditor.Properties.AutoHeight = false;
            bEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            bEditor.KeyDown += new KeyEventHandler(bEditor_KeyDown);
            bEditor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bEditor_ButtonClick);
            bEditor.Leave += new System.EventHandler(this.bEditor_Leave);
        }

        void dEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(dEditor);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                }
            }
            catch { }
        }
        void tEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(tEditor);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
                }
            }
            catch { }
        }
        void dEditor2_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(dEditor2);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                }
            }
            catch { }
        }
        void d2Editor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(dEditor2);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(dEditor2);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                    }
                }
            }
            catch { }
        }
        void dEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(dEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(dEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                    }
                }
            }
            catch { }
        }


        void bEditor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sVen = gridView1.GetRowCellDisplayText(iRow, gridColcVenCode).ToString().Trim();
                FrmVenInfo fVen = new FrmVenInfo(sVen);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    try
                    {
                        gridControl1.Controls.Remove(bEditor);
                        foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                        {
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, fVen.sVenCode);
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, fVen.sVenName);
                        }
                    }
                    catch { }
                    try
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenCode, fVen.sVenCode);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenName, fVen.sVenName);
                    }
                    catch { }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ù�Ӧ�̲���ʧ�ܣ�  " + ee.Message);
            }
        }
        void bEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                string sVenCode = bEditor.Text.Trim();

                DataTable dt = GetVendor(sVenCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, dt.Rows[0]["iID"].ToString().Trim());
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, dt.Rows[0]["iText"].ToString().Trim());
                    }
                }
                else
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, "");
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }

        }
        void bEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(bEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, bEditor.Text.Trim());
                    }
                    m_mergedCellsEdited = null;
                }
            }
            catch { }
        }

        GridCellInfoCollection m_mergedCellsEdited = null;

        void tEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(tEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(tEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, tEditor.EditValue);
                    }
                }
            }
            catch { }
        }
        GridHitInfo hInfo;
        GridView view;
        string sLastCol = "";
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                view = (GridView)sender;
                hInfo = view.CalcHitInfo(e.X, e.Y);
                if (hInfo.InRowCell)
                {
                    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);

                    {
                        if (gridControl1.Contains(tEditor))
                        {
                            gridControl1.Controls.Remove(tEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(bEditor))
                        {
                            gridControl1.Controls.Remove(bEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(dEditor))
                        {
                            gridControl1.Controls.Remove(dEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(dEditor2))
                        {
                            gridControl1.Controls.Remove(dEditor2);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                            }
                        }
                    }
                    if (cInfo is GridMergedCellInfo)
                    {
                        if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "qtynow")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(tEditor);
                            }

                            tEditor.Bounds = cInfo.Bounds;
                            tEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(tEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "cvencode")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(bEditor);
                            }

                            bEditor.Bounds = cInfo.Bounds;
                            bEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(bEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date2")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(dEditor2);
                            }

                            dEditor2.Bounds = cInfo.Bounds;
                            dEditor2.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(dEditor2);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date1")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(dEditor);
                            }

                            dEditor.Bounds = cInfo.Bounds;
                            dEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(dEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            //view = (GridView)sender;
            //hInfo = view.CalcHitInfo(e.X, e.Y);
            //if (hInfo.InRowCell)
            //{
            //    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
            //    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
            //    if (cInfo is GridMergedCellInfo)
            //    {
            //        if (!bEnable && (cInfo.Column.FieldName.Trim().ToLower() != "qtynow" || cInfo.Column.FieldName.Trim().ToLower() != "cvencode" || cInfo.Column.FieldName.Trim().ToLower() != "date2" || cInfo.Column.FieldName.Trim().ToLower() != "date1"))
            //        {
            //            return;
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "qtynow")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(tEditor);
            //            }

            //            tEditor.Bounds = cInfo.Bounds;
            //            tEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(tEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "cvencode")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(bEditor);
            //            }

            //            bEditor.Bounds = cInfo.Bounds;
            //            bEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(bEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date2")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(dEditor2);
            //            }

            //            dEditor2.Bounds = cInfo.Bounds;
            //            dEditor2.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(dEditor2);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date1")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(dEditor);
            //            }

            //            dEditor.Bounds = cInfo.Bounds;
            //            dEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(dEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        if (gridControl1.Contains(tEditor) && sLastCol != "qtynow")
            //        {
            //            gridControl1.Controls.Remove(tEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
            //            }
            //        }
            //        if (gridControl1.Contains(bEditor) && sLastCol != "cvencode")
            //        {
            //            gridControl1.Controls.Remove(bEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
            //            }
            //        }

            //        if (gridControl1.Contains(dEditor2) && sLastCol != "date2")
            //        {
            //            gridControl1.Controls.Remove(dEditor2);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
            //            }
            //        }

            //        if (gridControl1.Contains(dEditor) && sLastCol != "date1")
            //        {
            //            gridControl1.Controls.Remove(dEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "qtynow" && gridControl1.Contains(tEditor))
            //        {
            //            gridControl1.Controls.Remove(tEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "cvencode" && gridControl1.Contains(bEditor))
            //        {
            //            gridControl1.Controls.Remove(bEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "date1" && gridControl1.Contains(dEditor))
            //        {
            //            gridControl1.Controls.Remove(dEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "date2" && gridControl1.Contains(dEditor2))
            //        {
            //            gridControl1.Controls.Remove(dEditor2);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
            //            }
            //        }
            //    }
            //    sLastCol = cInfo.Column.FieldName.Trim().ToLower();
            //}
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

                string sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                if (! Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridColѡ��)))
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        double d = 0;
                        if (gridView1.GetRowCellValue(iRow, gridColiSendT).ToString().Trim() != "")
                        {
                            d = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiSendT));
                        }
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColPlanQty));

                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID && d1 > d)
                        {
                            gridView1.SetRowCellValue(i, gridColѡ��, true);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridColѡ��, false);
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        double d = 0;

                        if (gridView1.GetRowCellValue(i, gridColiSendT).ToString().Trim()!="")
                        {
                            d = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiSendT));
                        }
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColPlanQty));


                        if (d1 > d)
                        {
                            gridView1.SetRowCellValue(i, gridColѡ��, true);
                        }
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColѡ��, false);
                    }
                }

            }
            catch
            { }
        }

        private void SetColEnable(bool b)
        {
            gridColQtyNow.OptionsColumn.AllowEdit = b;
            gridColStartDate2.OptionsColumn.AllowEdit = b;
            gridColcVenCode.OptionsColumn.AllowEdit = b;
            gridColdate1.OptionsColumn.AllowEdit = b;
            gridColdate2.OptionsColumn.AllowEdit = b;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridView1.Columns["iQuantityI"] && radioQuantity.Checked)
                {
                    decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ʹ������"])), 6);
                    decimal d2 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"])), 6);
                    if (radioNum.Enabled == false)      //��������λradioNum��EnableΪfalse
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d2 / d1, 0));
                    }
                    else
                    {
                        decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"])), 6);

                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d2 / d1, 0));
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"], decimal.Round(d2 / d, 6));
                    }
                }
                if (e.Column == gridView1.Columns["iNumI"] && radioNum.Checked)
                {

                    decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"])), 6);
                    decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ʹ������"])), 6);
                    decimal d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"])), 6);

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"], decimal.Round(d * d3, 6));

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d * d3 / d1, 0));
                }

                if (radioParent.Checked && e.Column == gridView1.Columns["QtyNow"])
                {
                    string siID = gridView1.GetRowCellValue(e.RowHandle, gridColiID).ToString().Trim();
                    decimal d4 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"])), 6);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColInvCode) == null || gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim() == string.Empty)
                            continue;
                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                        {
                            decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["ʹ������"])), 6);
                            if (radioNum.Enabled)
                            {
                                decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["ChangeRate"])), 6);
                                gridView1.SetRowCellValue(i, gridView1.Columns["iNumI"], decimal.Round(d4 * d1 / d, 6));
                            }

                            decimal d5 = d4 * d1;
                            gridView1.SetRowCellValue(i, gridColiQuantityI, d5);
                        }
                    }
                }

                if ((e.Column == gridView1.Columns["iNumI"] || e.Column == gridView1.Columns["iQuantityI"]) && !radioParent.Checked)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"]).ToString().Trim() != "" && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"])) != 0)
                    {
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"]));
                        double d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"]));
                        double d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"]));

                        if (d3 * d2 / 1.15 > d1 || d1 > d3 * d2 * 1.15)
                        {
                            MessageBox.Show("��" + (e.RowHandle + 1) + "�����ݲ��ܳ��������ʵ�15%");
                        }
                    }
                }

                if (e.Column == gridColcVenCode)
                {
                    try
                    {
                        string siID = gridView1.GetRowCellValue(e.RowHandle, gridColiID).ToString().Trim();
                        string sTxt = gridView1.GetRowCellValue(e.RowHandle, gridColcVenCode).ToString().Trim();
                        string sInvCode = gridView1.GetRowCellValue(e.RowHandle, gridColInvCode).ToString().Trim();
                        DataTable dt = GetVendor(sTxt);
                        DataTable dtPrice = GetVendPriceInfo(sInvCode, sTxt);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, dt.Rows[0]["iText"].ToString().Trim());
                                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, dtPrice.Rows[0]["iTaxPrice"]);
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, dtPrice.Rows[0]["iTaxRate"]);
                                    }
                                    else
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, DBNull.Value);
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, DBNull.Value);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, DBNull.Value);
                                    gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, DBNull.Value);
                                    gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, DBNull.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
                    }
                }
                int iRow = e.RowHandle;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                decimal d1 = 0;
                if (gridView1.GetRowCellValue(e.RowHandle, gridColCanUseQty).ToString().Trim() != "")
                {
                    d1 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColCanUseQty));
                }
                decimal d2 = 0;
                if (gridView1.GetRowCellValue(e.RowHandle, gridColiQuantityI).ToString().Trim() != "")
                {
                    d2 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantityI));
                }
                if (d2 > d1)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
            }
            catch { }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                {
                    if (chkNeedDate.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColdate2, dateNeed.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (chkEndDate.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColdate1, dateEnd.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (chkVenPG.Checked)
                    {
                        if (txtVenNamePG.Text.Trim() != "")
                        {
                            gridView1.SetRowCellValue(i, gridColcVenCode, txtVenCodePG.Text);
                            gridView1.SetRowCellValue(i, gridColcVenName, txtVenNamePG.Text);


                        }
                        else
                        {
                            MessageBox.Show("��ѡ�����Ĺ�Ӧ�̣�");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���ݴ�������жϹ�Ӧ�� 1. ��Ӧ�̴���۸�������� 2. ���һ��ί�⳧��
        /// </summary>
        /// <param name="p">�������</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p)
        {
            try
            {
                DataView dv = new DataView(dt��Ӧ�̴���۸�);
                dv.RowFilter = " cInvCode = '" + p + "' ";
                return dv.ToTable();
            }
            catch (Exception ee)
            {
                throw new Exception("��ù�Ӧ��������Ϣʧ�ܣ�\n  " + ee.Message);
            }
        }

        /// <summary>
        /// ��Ӧ�̴���۸��������
        /// </summary>
        /// <param name="p">�������</param>
        /// <param name="sVend">��Ӧ�̱���</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p, string sVend)
        {
            try
            {
                //if (dt��Ӧ�̴���۸� == null)
                //{
                  Get��Ӧ�̴���۸�(sVend, p);
                //}

                //DataView dv = new DataView(dt��Ӧ�̴���۸�);
                //dv.RowFilter = " cInvCode = '" + p + "' and cVenCode = '" + sVend + "' ";
                //return dv.ToTable();
                  return dt��Ӧ�̴���۸�;
            }
            catch (Exception ee)
            {
                throw new Exception("��ù�Ӧ��������Ϣʧ�ܣ�\n  " + ee.Message);
            }
        }

        /// <summary>
        /// ��Ӧ�̲���
        /// </summary>
        private void GetDepInfo()
        {
            try
            {
                string sSQL = "select distinct v.cVenDepart as iID,d.cDepName as iText from @u8.vendor v left join @u8.Department d on v.cVenDepart = d.cDepCode where v.cVenDepart is not null order by v.cVenDepart,d.cDepName ";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                ItemLookUpEditVenDepartment.DataSource = dt;
                lookUpEditVenDep.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ò�����Ϣʧ�ܣ�" + ee.Message);
            }
        }


        private void GetlookUpEditEnSure()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["iID"] = DBNull.Value;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "����";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "�ɹ�";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "ί��";
                dt.Rows.Add(dr);

                lookUpEditEnSure.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��üƻ�ȷ����Ϣʧ�ܣ�" + ee.Message);
            }
        }

        private void btnEnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");
                if (lookUpEditEnSure.Text.Trim() == "")
                {
                    MessageBox.Show("��ѡ��ƻ�ȷ�ϣ�");
                    lookUpEditEnSure.Focus();
                    return;
                }
                ArrayList aList = new ArrayList();
                ArrayList aLRow = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        sSQL = "if exists(select * from UFDLImport..OMPlanDay_Info where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "') " +
                                "	update UFDLImport..OMPlanDay_Info set EnSureUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',EnSureDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',EnSureDepment = '" + lookUpEditEnSure.Text.Trim() + "'  where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "'" +
                                " else " +
                                "	insert into UFDLImport..OMPlanDay_Info(iID,EnSureUser,EnSureDate,EnSureDepment,cCode)values('" + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "','" + lookUpEditEnSure.Text.Trim() + "','" + sCode + "') ";

                        aList.Add(sSQL);

                        aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ȷ�ϳɹ���");

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < aLRow.Count; j++)
                        {
                            if (aLRow[j].ToString().Trim() == gridView1.GetRowCellValue(i, gridColiID).ToString().Trim())
                            {
                                gridView1.SetRowCellValue(i, gridColcCode, sCode);
                                gridView1.SetRowCellValue(i, gridColEnSureDate,FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                                gridView1.SetRowCellValue(i, gridColEnSureDepment, lookUpEditEnSure.Text.Trim());
                                gridView1.SetRowCellValue(i, gridColEnSureUser,FrameBaseFunction.ClsBaseDataInfo.sUserName);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("ȷ��ʧ��!" + ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            string sVenCode = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cVenCode"]).ToString().ToLower();
            if (bBtnType && (sVenCode == "98" || sVenCode == "" || sVenCode == "0487" || sVenCode == "0462" || sVenCode == "0482" || sVenCode == "0415"))
            {
                gridColcVenCode.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridColcVenCode.OptionsColumn.AllowEdit = false;
            }
            if (!bBtnType)
            {
                gridColcVenCode.OptionsColumn.AllowEdit = true;
            }

            string s = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["ChangeRate"]).ToString().Trim().ToLower();//53
            if (s == "")
            {
                gridColiNumI.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColiNumI.OptionsColumn.AllowEdit = true;
            }

            if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cAssComUnitCodeI"]) != null && gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cAssComUnitCodeI"]).ToString().Trim() != string.Empty)
            {
                radioNum.Enabled = true;
            }
            else
            {
                radioNum.Enabled = false;
            }
            if (radioNum.Enabled == true)
            {
                gridView1.Columns["iNumI"].OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridView1.Columns["iNumI"].OptionsColumn.AllowEdit = false;
            }

            if (radioQuantity.Checked || radioNum.Checked)
            {
                gridColiQuantityI.OptionsColumn.AllowEdit = true;
                gridColiNumI.OptionsColumn.AllowEdit = true;

                string sID = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiID).ToString().Trim();
                int iCou = 0;                //�Ƿ�һ�Զ�����
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID) != null && gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID)
                    {
                        iCou += 1;
                    }
                }
                if (iCou > 1)
                {
                    gridColiQuantityI.OptionsColumn.AllowEdit = false;
                    gridColiNumI.OptionsColumn.AllowEdit = false;
                }
            }

            if (e.FocusedRowHandle > 0)
            {
                string s�Ӽ����� = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColcInvCode).ToString().Trim();
                string s������ = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColRemarkXB).ToString().Trim();
                bool b = true;
                for (int i = 0; i < e.FocusedRowHandle; i++)
                {
                    string s�Ӽ�����2 = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                    string s������2 = gridView1.GetRowCellValue(i, gridColRemarkXB).ToString().Trim();
                    string s�����µ�2 = gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim();
                    double d�����µ�2 = 0;
                    try
                    {
                        if (s�����µ�2 != "")
                        {
                            d�����µ�2 = double.Parse(s�����µ�2);
                        }
                    }
                    catch
                    {
                        d�����µ�2 = -1;
                    }

                    if (s�Ӽ����� == s�Ӽ�����2 && s������ != s������2)
                    {
                        if (s�����µ�2 == "" || s�����µ�2 == "0" || d�����µ�2 == 0)
                        {
                            b = false;
                            break;
                        }
                    }
                }
                gridView1.OptionsBehavior.Editable = b;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = true;
            }
        }

        private void GetWareHouse()
        {
            string sSQL = "select cWhCode,cWhName,bFreeze from @u8.Warehouse where bFreeze = 0 order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWoreHouse.DataSource = dt;
        }

        private void btnUnEnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");
                ArrayList aList = new ArrayList();
                ArrayList aLRow = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        sSQL = "update UFDLImport..OMPlanDay_Info set EnSureUser =null,EnSureDate = null,EnSureDepment = null where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "'";
                        aList.Add(sSQL);
                        aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ȡ���ɹ���");
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < aLRow.Count; j++)
                        {
                            if (aLRow[j].ToString().Trim() == gridView1.GetRowCellValue(i, gridColiID).ToString().Trim())
                            {
                                gridView1.SetRowCellValue(i, gridColcCode, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureDate, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureDepment, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureUser, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// ����ۼ���������������Ϣ
        /// </summary>
        private void GetQty()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiSumOutQty) != null && gridView1.GetRowCellValue(i, gridColiSumOutQty).ToString().Trim() != "")
                {
                    continue;
                }
                string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                decimal d1 = 0;     //�ִ���
                decimal d2 = 0;     //�ۼ�����
                decimal d3 = 0;     //����
                decimal d5 = 0;     //�����µ�
                bool bCanOut = true;   //�㹻����

                if (gridView1.GetRowCellValue(i, gridColCurrQtyI).ToString().Trim() != "")
                {
                    d1 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColCurrQtyI));
                }
                if (gridView1.GetRowCellValue(i, gridColiSumOutQty).ToString().Trim() != "")
                {
                    d2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiSumOutQty));
                }
                if (gridView1.GetRowCellValue(i, gridColiYuQty).ToString().Trim() != "")
                {
                    d3 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiYuQty));
                }

                for (int j = i; j < gridView1.RowCount; j++)
                {
                    if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() != "")
                    {
                        d5 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI));
                    }
                    string sInvCode2 = gridView1.GetRowCellValue(j, gridColcInvCode).ToString().Trim();
                    if (i == j)
                    {
                        if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() == "")
                            d2 = 0;
                        else
                            d2 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI));
                    }
                    else
                    {
                        if (sInvCode != sInvCode2)
                        {
                            continue;
                        }
                        if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() != "")
                            d2 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI)) + d2;
                    }
                    d3 = d1 - d2;
                    gridView1.SetRowCellValue(j, gridColiSumOutQty, d2);
                    if (d3 > 0)
                    {
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }
                    else
                    {
                        d3 = 0;
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }

                    decimal d4 = 0;     //���ο���������
                    if (gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim() != "")
                    {
                        d4 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiQuantityI));
                    }
                    if (i == j)
                    {
                        if (d1 >= d5)
                        {
                            gridView1.SetRowCellValue(i, gridColiQtyCanOut, d5);
                            bCanOut = true;
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, gridColiQtyCanOut, d1);
                            bCanOut = false;
                        }
                    }
                    else
                    {
                        if (sInvCode != sInvCode2)
                        {
                            continue;
                        }
                        if (bCanOut)
                        {
                            if (d2 - d5 > d1)
                            {
                                gridView1.SetRowCellValue(j, gridColiQtyCanOut, d2 - d5);
                                bCanOut = true;
                            }
                            else
                            {
                                if (d1 - (d2 - d5) > d5)
                                {
                                    gridView1.SetRowCellValue(j, gridColiQtyCanOut, d5);
                                    bCanOut = true;
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(j, gridColiQtyCanOut, d1 - (d2 - d5));
                                    bCanOut = false;
                                }
                            }
                        }
                        else
                        {
                            gridView1.SetRowCellValue(j, gridColiQtyCanOut, 0);
                            bCanOut = false;
                        }
                    }

                }
                for (int j = gridView1.RowCount - 1; j >= i ; j--)
                {
                    string sInvCode2 = gridView1.GetRowCellValue(j, gridColcInvCode).ToString().Trim();
                    if (sInvCode2 == sInvCode)
                    {
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }
                }
            }
        }

        private void chkDateNeed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateNeed.Checked)
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

        private void chkVenPG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVenPG.Checked)
            {
                txtVenCodePG.Text = "";
                txtVenCodePG.Enabled = true;
            }
            else
            {
                txtVenCodePG.Enabled = false;
            }
        }

        private void txtVenCodePG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCodePG.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCodePG.Text = fVen.sVenCode;
                txtVenNamePG.Text = fVen.sVenName;
            }
        }

        private void txtVenCodePG_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCodePG.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenCodePG.Text = dt.Rows[0]["iID"].ToString().Trim();
                    txtVenNamePG.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtVenCodePG.Text = "";
                    txtVenCodePG.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }
        }

        private void chkNeedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNeedDate.Checked)
            {
                dateNeed.Enabled = true;
            }
            else
            {
                dateNeed.Enabled = false;
            }
        }

        private void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEndDate.Checked)
            {
                dateEnd.Enabled = true;
            }
            else
            {
                dateEnd.Enabled = false;
            }
        }

        private void btnSaveVen_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if  (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridColѡ��)))
                    {
                        if (gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                        {
                            sErr = sErr + "�� " + (i + 1) + " ��Ӧ�̲���Ϊ�� \n";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim() == "")
                        {
                            sErr = sErr + "�� " + (i + 1) + " δ���ò��ϼ۸�\n";
                            continue;
                        }

                        sSQL = "update UFDLImport..OMPlan set cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and accid ='200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";

                        aList.Add(sSQL);
                    }
                }
                if (sErr != "")
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "����ʧ��";
                    fMsgBos.richTextBox1.Text = "����ʧ�ܣ�ԭ�����£�\n" + sErr;
                    fMsgBos.ShowDialog();
                    return;
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("����ɹ���");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ�ܣ� " + ee.Message);
            }
        }

        private void datePlan_EditValueChanged(object sender, EventArgs e)
        {
            dateEdit1.DateTime = datePlan.DateTime;
            dateEdit2.DateTime = datePlan.DateTime.AddDays(3);
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("û������");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("isnull(bCreateDayPlan,0)=0");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("û������");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("isnull(bCreateDayPlan,0)=1");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("û������");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("1=1");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio1toN_CheckedChanged(object sender, EventArgs e)
        {
            if (radio1toN.Checked)
            {
                MessageBox.Show("һ�Զ������ʹ��������ע�ⲻҪ��©�Ӽ�");
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                MessageBox.Show("һ�Զ������ʹ��������ע�ⲻҪ��©�Ӽ�");
            }
        }


        private void Get��Ӧ�̴���۸�(string sVenCode,string sInvCode)
        {
            sSQL = @"
 select *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice from 
        ( 
            select max(Autoid) as Autoid from @u8.ven_inv_price group by cvencode,cInvCode 
        ) vT left join @u8.ven_inv_price v on v.Autoid = vT.autoid   
         left join @u8.vendor vd on vd.cVenCode = v.cVenCode                             
where v.iSupplyType = '2' 
    and v.cVenCode = '111111' and v.cInvCode = '222222'
order by v.iunitprice,v.Autoid
";
            sSQL = sSQL.Replace("111111", sVenCode);
            sSQL = sSQL.Replace("222222", sInvCode);
            dt��Ӧ�̴���۸� = clsSQLCommond.ExecQuery(sSQL);
        }

        private void Frmί���ռƻ�_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 20;
            //groupBox1.Height = this.Height - 160;
            gridControl1.Width = groupBox1.Width - 20;
            gridControl1.Height = groupBox1.Height - 280;
        }
    }
}