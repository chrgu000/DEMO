using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm����Ԥ���Ʒ��� : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}


        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Frm����Ԥ���Ʒ���()
        {
            InitializeComponent();
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
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
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtcCode.Text = "";
                lookUpEditcRdName.EditValue = "1202";
                Frm����Ԥ���Ʒ������� frm = new Frm����Ԥ���Ʒ�������(Conn);
                DialogResult d = frm.ShowDialog();
                if (d != DialogResult.OK)
                {
                    MessageBox.Show("ȡ������");
                    return;
                }
                
                DataTable dt = frm.dtGrid.Copy();
                if (dt != null && dt.Rows.Count > 0)
                {
                    //DataColumn dc = new DataColumn();
                    //dc.ColumnName = "cFree1";
                    //dt.Columns.Add(dc);

                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "cBatch";
                    dt.Columns.Add(dc);

                    //dc = new DataColumn();
                    //dc.ColumnName = "cItemCode";
                    //dt.Columns.Add(dc);

                    gridControl1.DataSource = dt;
                    chkAll.Checked = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("������������ʧ�ܣ�" + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cCode from SA_PreOrderMain order by cCode";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            //lookUpEditcCode1.Properties.DataSource = dt;
            //lookUpEditcCode2.Properties.DataSource = dt;

            sSQL = @"
select cInvCode ,cInvName,cInvStd,a.cComunitCode ,b.cComUnitName
from Inventory a left join ComputationUnit b on a.cComunitCode = b.cComunitCode 
order by cInvCode
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcInvCode.DataSource = dt;
            ItemLookUpEditcInvName.DataSource = dt;
            ItemLookUpEditcInvStd.DataSource = dt;
            ItemLookUpEditcComUnitName.DataSource = dt;

            sSQL = "select cCusCode,cCusName from Customer order by cCusCode";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //lookUpEdit�ͻ�����.Properties.DataSource = dt;
            ItemLookUpEditcCusCode.DataSource = dt;
            ItemLookUpEditcCusName.DataSource = dt;

            sSQL = "select cValue from UserDefine where cID=03  ORDER BY cAlias";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            ItemLookUpEditcDepCode.DataSource = dt;
            ItemLookUpEditcDepName.DataSource = dt;
            lookUpEditcDepName.Properties.DataSource = dt;

            sSQL = "select cWhCode,cWhName from Warehouse order by cWhCode";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEditcWhName.Properties.DataSource = dt;
            lookUpEditcWhName.EditValue = "JK004";

            sSQL = "select cRdCode,cRdName from Rd_Style where bRdFlag = 1 and bRdEnd = 1 order by cRdCode";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            lookUpEditcRdName.Properties.DataSource = dt;
            lookUpEditcRdName.EditValue = "111";

            //sSQL = "select cPersonCode,cPersonName from Person where cDepCode='JK1200' order by cPersonCode";
            //dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            //dr = dt.NewRow();
            //dt.Rows.InsertAt(dr, 0);
            //lookUpEditPersonName.Properties.DataSource = dt;

            sSQL = @"
SELECT cast(0 as bit) as bRefSelectColumn,[UserdefineEntity_UserDefine].[cAlias] as Calias,[UserdefineEntity_UserDefine].[cValue] as Cvalue 
FROM [UserDefine] AS [UserdefineEntity_UserDefine]
WHERE 1=1  and ([UserdefineEntity_UserDefine].[cID]=N'20')
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEdit��װ.Properties.DataSource = dt;

            sSQL = @"
--select citemcode,citemname,bclose,citemccode from fItemss00 where (1=1) and ( isnull(bclose,0)=0 ) order by citemcode
select cValue from UserDefine where cID=28  ORDER BY cAlias
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcitemname.Properties.DataSource = dt;

            sSQL = @"
select cValue from UserDefine where cID=29  ORDER BY cAlias
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcDefine3.Properties.DataSource = dt;

            sSQL = @"
select cPosCode,cPosName from Position 
";
            dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditcPosition.Properties.DataSource = dt;
            
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                txtcCode.Text = "";
                dateEdit1.DateTime = DateTime.Today;

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColѡ��, chkAll.Checked);
                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (dateEdit1.Text.Trim() == "")
                {
                    dateEdit1.Focus();
                    throw new Exception("������ڲ���Ϊ��");
                }
                if (lookUpEditcWhName.Text.Trim() == "")
                {
                    lookUpEditcWhName.Focus();
                    throw new Exception("�ֿⲻ��Ϊ��");
                }
                if (lookUpEditcDepName.Text.Trim() == "")
                {
                    lookUpEditcDepName.Focus();
                    throw new Exception("���Ų���Ϊ��");
                }
                if (textEdit����Ա.Text.Trim() == "")
                {
                    textEdit����Ա.Focus();
                    throw new Exception("����Ա����Ϊ��");
                }
                //if (txtRemark.Text.Trim() == "")
                //{
                //    txtRemark.Focus();
                //    throw new Exception("����ժҪ����Ϊ��");
                //}

                string sErr = "";



                int iCouRow = 0;
              

                int iCou = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "";
                    DataTable dt = new DataTable();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (TH.BaseClass.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            iCouRow += 1;

                            string cInvCode = gridView1.GetRowCellValue(i, gridCol�������).ToString().Trim();
                            sSQL = "select * from Inventory where cInvCode = '" + cInvCode + "'";
                            dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dt == null || dt.Rows.Count < 1)
                            {
                                sErr = sErr + "�� " + (i + 1).ToString() + " ���������\n";
                            }

                            if (TH.BaseClass.BaseFunction.ReturnBool(dt.Rows[0]["bInvBatch"]))
                            {
                                if (gridView1.GetRowCellValue(i, gridColcBatch).ToString().Trim() == "")
                                {
                                    sErr = sErr + "�� " + (i + 1).ToString() + " ����������\n";
                                }
                            }

                            if (TH.BaseClass.BaseFunction.ReturnBool(dt.Rows[0]["bFree1"]))
                            {
                                if (gridView1.GetRowCellValue(i, gridCol��װ).ToString().Trim() == "")
                                {
                                    sErr = sErr + "�� " + (i + 1).ToString() + " �������װ\n";
                                }
                            }

                            if (gridView1.GetRowCellValue(i, gridColcPosition).ToString().Trim() == "")
                            {
                                sErr = sErr + "�� " + (i + 1).ToString() + " �������λ\n";
                            }

                            if (gridView1.GetRowCellValue(i, gridColcItemCode).ToString().Trim() == "")
                            {
                                sErr = sErr + "�� " + (i + 1).ToString() + " �����������\n";
                            }

                            if (gridView1.GetRowCellValue(i, gridColcPosition).ToString().Trim() == "")
                            {
                                sErr = sErr + "�� " + (i + 1).ToString() + " ���������\n";
                            }

                        }
                    }
                    if (iCouRow == 0)
                    {
                        throw new Exception("��������ѡ��һ������");
                    }

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    //sLogDate

                    DateTime dLog = DateTime.Today;
                    if(sLogDate != "")
                    {
                        dLog = TH.BaseClass.BaseFunction.ReturnDate(sLogDate);
                    }
                    //��õ��ݺ�
                    sSQL = "select cNumber from VoucherHistory Where CardNumber='0411' and cSeed = '" + dLog.ToString("yyyyMM") + "'";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCode = TH.BaseClass.BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                        lCode += 1;
                        sSQL = "update  VoucherHistory set cNumber = '" + lCode.ToString() + "' Where CardNumber='0411'  and cSeed = '" + dLog.ToString("yyyyMM") + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        lCode = 1;
                        sSQL = "insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)" +
                                "values('0411','����','��','" + dLog.ToString("yyyyMM") + "','1',0)";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    string sCode = lCode.ToString();
                    while (sCode.Length < 3)
                    {
                        sCode = "0" + sCode;
                    }

                    sCode = "JKCP" + dLog.ToString("yyMMdd") + sCode;

                    long lID = 0;
                    long lIDDetails = 0;
                    //sSQL = "select iFatherId,iChildId from UFSystem.dbo.UA_Identity where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
                    //dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    lID = TH.BaseClass.BaseFunction.ReturnLong(dt.Rows[0]["iFatherId"]);
                    //    lIDDetails = TH.BaseClass.BaseFunction.ReturnLong(dt.Rows[0]["iChildId"]);
                    //}

                    sSQL = @"
declare @p5 int
set @p5=111111
declare @p6 int
set @p6=222222
exec sp_GetId N'',N'001',N'rd',333333,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("111111", lID.ToString());
                    sSQL = sSQL.Replace("222222", lIDDetails.ToString());
                    sSQL = sSQL.Replace("333333", iCouRow.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = TH.BaseClass.BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = TH.BaseClass.BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    sSQL = "select * from AccInformation where  cSysId =N'ST' and  cName= N'bProductInCheck'";
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    bool b��Ʒ�������޸��ִ��� = TH.BaseClass.BaseFunction.ReturnBool(dt.Rows[0]["cValue"]);

                    UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecord10 model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecord10();

                    lID += 1;
                    #region ��ͷ
                    
                    model.ID = lID;
                    model.bRdFlag = 1;
                    model.cVouchType = "10";
                    model.cBusType = "��Ʒ���";
                    model.cSource = "���";
                    //model.cBusCode 
                    model.cWhCode = lookUpEditcWhName.EditValue.ToString();
                    model.dDate = dateEdit1.DateTime;
                    model.cCode = sCode;
                    model.cRdCode = lookUpEditcRdName.EditValue.ToString().Trim();
                    //model.cDepCode = lookUpEditcDepName.EditValue.ToString().Trim();
                    //if (lookUpEditPersonName.EditValue != null)
                    //{
                    //    model.cPersonCode = lookUpEditPersonName.EditValue.ToString().Trim();
                    //}
                    //model.cPTCode
                    //model.cSTCode
                    //model.cCusCode
                    //model.cVenCode
                    //model.cOrderCode
                    //model.cARVCode
                    //model.cBillCode
                    //model.cDLCode
                    //model.cProBatch
                    //model.cHandler = sUserName;
                    model.cMemo = txtRemark.Text.Trim();
                    model.bTransFlag = false;
                    //model.cAccounter
                    model.cMaker = sUserName;
                    //model.cDefine1
                    //model.cDefine2
                    model.cDefine3 = lookUpEditcDepName.EditValue.ToString().Trim();
                    //model.cDefine4
                    //model.cDefine5
                    //model.cDefine6
                    //model.cDefine7
                    model.cDefine8 = textEdit����Ա.EditValue.ToString();
                    //model.cDefine9
                    //model.cDefine10
                    //model.cDefine11
                    //model.cDefine12
                    //model.cDefine13
                    //model.cDefine14
                    //model.cDefine15
                    //model.cDefine16
                    //model.dKeepDate
                    //model.dVeriDate
                    model.bpufirst = false;
                    model.biafirst = false;
                    //model.iMQuantity
                    //model.dARVDate
                    //model.cChkCode
                    //model.dChkDate
                    //model.cChkPerson
                    model.VT_ID = 63;
                    model.bIsSTQc = false;
                    //model.cMPoCode
                    //model.gspcheck
                    //model.ipurorderid
                    model.iproorderid = 0;
                    //model.ufts
                    //model.iExchRate
                    //model.cExch_Name
                    //model.bOMFirst
                    model.bFromPreYear = false;
                    //model.bIsLsQuery
                    model.bIsComplement = 0;
                    model.iDiscountTaxType = 0;
                    model.ireturncount = 0;
                    model.iverifystate = 0;
                    model.iswfcontrolled = 1;
                    //model.cModifyPerson
                    model.dnmaketime = DateTime.Now;
                    //model.dnmodifytime
                    //model.dnverifytime = DateTime.Now;
                    model.bredvouch = 0;
                    //model.iFlowId 
                    //model.cPZID
                    //model.cSourceCodeLs
                    model.iPrintCount = 0;
                    //model.csysbarcode 
                    //model.cCurrentAuditor 

                    #endregion

                    UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecord10 dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecord10();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!TH.BaseClass.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColѡ��)))
                            continue;

                        if (gridView1.GetRowCellValue(i, gridColcBatch).ToString().Trim() == "")
                        {
                            throw new Exception("��" + (i + 1).ToString() + " ���Ų���Ϊ��");
                        }

                        if (gridView1.GetRowCellValue(i, gridColcPosition).ToString().Trim() == "")
                        {
                            throw new Exception("��" + (i + 1).ToString() + " �ⷿ����Ϊ��");
                        }

                        if (gridView1.GetRowCellValue(i, gridColcDefine3).ToString().Trim() == "")
                        {
                            throw new Exception("��" + (i + 1).ToString() + " ��������Ϊ��");
                        }

                        if (gridView1.GetRowCellValue(i, gridColcItemCode).ToString().Trim() == "")
                        {
                            throw new Exception("��" + (i + 1).ToString() + " ����ֲ���Ϊ��");
                        }


                        lIDDetails += 1;

                        UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords10 models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords10();

                        #region ����

                        models.AutoID = lIDDetails;
                        models.ID = lID;
                        models.cInvCode = gridView1.GetRowCellValue(i, gridCol�������).ToString().Trim();
                        models.iQuantity = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i,gridColUniQty));
                        if(models.iQuantity <= 0)
                        {
                            throw new Exception("��" + (i+1).ToString() +" �����������0");
                        }
                        if (TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiNum)) != 0)
                        {
                            models.iNum = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniNum));
                        }

                        //models.iUnitCost
                        //models.iPrice
                        //models.iAPrice
                        //models.iPUnitCost
                        //models.iPPrice
                        models.cBatch = gridView1.GetRowCellValue(i, gridColcBatch).ToString().Trim();
                        //models.cVouchCode
                        //models.cInVouchCode
                        //models.cinvouchtype
                        //models.iSOutQuantity
                        //models.iSOutNum
                        models.cFree1 = gridView1.GetRowCellDisplayText(i, gridCol��װ).ToString().Trim();
                        //models.cFree2
                        models.iFlag = 0;
                        //models.iFNum 
                        //models.iFQuantity
                        //models.dVDate
                        models.cPosition = gridView1.GetRowCellValue(i, gridColcPosition).ToString().Trim();
                        //models.cDefine22
                        //models.cDefine23
                        //models.cDefine24
                        //models.cDefine25
                        //models.cDefine26
                        //models.cDefine27
                        //models.cItem_class = "00";
                        //models.cItemCode = gridView1.GetRowCellValue(i, gridColcItemCode).ToString().Trim();
                        //models.cName
                        //models.cItemCName
                        models.cFree3 = gridView1.GetRowCellValue(i, gridColcItemCode).ToString().Trim();
                        models.cFree4 = gridView1.GetRowCellValue(i, gridColcDefine3).ToString().Trim();
                        //models.cFree5
                        //models.cFree6
                        //models.cFree7
                        //models.cFree8
                        //models.cFree9
                        //models.cFree10
                        //models.cBarCode
                        //models.iNQuantity
                        //models.iNNum
                        //models.cAssUnit
                        //models.dMadeDate
                        //models.iMassDate
                        //models.cDefine28
                        //models.cDefine29
                        //models.cDefine30
                        //models.cDefine31
                        //models.cDefine32
                        //models.cDefine33
                        //models.cDefine34
                        //models.cDefine35
                        //models.cDefine36
                        //models.cDefine37
                        //models.iMPoIds
                        //models.iCheckId
                        //models.cBVencode
                        //models.bGsp
                        //models.cGspState
                        //models.cCheckCode
                        //models.iCheckIdBaks
                        //models.cRejectCode
                        //models.iRejectIds
                        //models.cCheckPersonCode
                        //models.dCheckDate
                        //models.cMassUnit
                        //models.cMoLotCode
                        //models.bChecked
                        models.bLPUseFree = false;
                        models.iRSRowNO = 0;
                        models.iOriTrackID = 0;
                        //models.coritracktype
                        //models.cbaccounter
                        models.bCosting = true;
                        models.bVMIUsed = false;
                        //models.iVMISettleNum
                        //models.iVMISettleNum
                        //models.cvmivencode
                        //models.iInvSNCount
                        //models.cwhpersoncode
                        //models.cwhpersonname
                        //models.cservicecode

                        if (models.iNum != 0)
                        {
                            models.iinvexchrate = TH.BaseClass.BaseFunction.ReturnDecimal(models.iQuantity / models.iNum);
                        }
                        //models.corufts
                        //models.cmocode
                        //models.imoseq
                        //models.iopseq
                        //models.copdesc
                        //models.strContractGUID
                        models.iExpiratDateCalcu = 0;
                        //models.cExpirationdate
                        //models.cciqbookcode
                        //models.iBondedSumQty
                        //models.productinids
                        models.iordertype = 0;
                        //models.iordercode
                        //models.iorderseq
                        models.isotype = 0;
                        //models.csocode
                        //models.isoseq
                        //models.cBatchProperty1
                        //models.cBatchProperty2
                        //models.cBatchProperty3
                        //models.cBatchProperty4
                        //models.cBatchProperty5
                        models.cBatchProperty6 = gridView1.GetRowCellValue(i, gridColcBatchProperty6).ToString().Trim();
                        models.cBatchProperty7 = gridView1.GetRowCellValue(i, gridColcBatchProperty7).ToString().Trim();
                        models.cBatchProperty8 = gridView1.GetRowCellValue(i, gridColcBatchProperty8).ToString().Trim();
                        models.cBatchProperty9 = gridView1.GetRowCellValue(i, gridColcBatchProperty9).ToString().Trim();
                        //models.cBatchProperty10
                        //models.cbMemo
                        models.irowno = i + 1;
                        //models.strowguid
                        //models.cservicecode
                        models.bmergecheck = false;
                        models.SA_PreOrderDetailsID = TH.BaseClass.BaseFunction.ReturnLong(gridView1.GetRowCellValue(i, gridCol������ID));
                        
                        #endregion

                        UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords10 dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.rdrecords10();
                        sSQL = dals.Add(models);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "exec SP_ClearCurrentStock_ST";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "update SA_PreOrderDetails set cDefine26=isnull(cDefine26,0)+" + models.iQuantity + " where autoid='" + gridView1.GetRowCellValue(i, gridCol������ID).ToString().Trim() + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        //�������Ԥ������ȫ������Զ��ر�
                        sSQL = "select sum(iQuantity-isnull(cDefine26,0)) as iSum from SA_PreOrderDetails where AutoID='" + gridView1.GetRowCellValue(i, gridCol������ID).ToString().Trim() + "'";
                        DataTable dtsumDetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal iSumDetails = TH.BaseClass.BaseFunction.ReturnDecimal(dtsumDetails.Rows[0]["iSum"].ToString());
                        if (iSumDetails == 0)
                        {
                            sSQL = "update SA_PreOrderDetails set cSCloser  ='" + sUserID + "' where AutoID='" + gridView1.GetRowCellValue(i, gridCol������ID).ToString().Trim() + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        sSQL = @"select a.ID into #a from SA_PreOrderMain a left join SA_PreOrderDetails b on a.ID=b.ID where b.AutoID='" + gridView1.GetRowCellValue(i, gridCol������ID).ToString().Trim() + "'"+
                        "select a.ID,sum(iQuantity-isnull(cDefine26,0)) as iSum from #a a left join SA_PreOrderDetails b on a.ID=b.ID group by a.ID";
                        DataTable dtsum=DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        decimal iSum = TH.BaseClass.BaseFunction.ReturnDecimal(dtsum.Rows[0]["iSum"].ToString());
                        string iID = dtsum.Rows[0]["ID"].ToString();

                        if (iSum == 0)
                        {
                            sSQL = "update SA_PreOrderMain set cCloser ='" + sUserID + "' where ID='" + iID + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        //��λ�Ǽ�
                        sSQL = "insert into InvPosition( RdsID, RdID, cWhCode, cPosCode, cInvCode, cBatch, cFree1, cFree2, dVDate, iQuantity" +
                                    ", iNum, cMemo, cHandler, dDate, bRdFlag, cSource, cFree3, cFree4, cFree5, cFree6" +
                                    ", cFree7, cFree8, cFree9, cFree10, cAssUnit, cBVencode, iTrackId,  dMadeDate, iMassDate" +
                                    ", cMassUnit, cvmivencode, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cvouchtype, cInVouchType, cVerifier, dVeriDate, dVouchDate) " +
                                "values(" + lIDDetails + "," + lID + ",'" + model.cWhCode + "','" + models.cPosition + "','" + models.cInvCode + "'," + models.cBatch + ",'" + models.cFree1 + "','" + models.cFree2 + "',null," + models.iQuantity + " " +
                                ",NULL,null,'" + sUserName + "','" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "',1,null,'" + models.cFree3 + "','" + models.cFree4 + "','" +models.cFree5 + "','" + models.cFree6 + "'" +
                                ",'" + models.cFree7 + "','" + models.cFree8 + "','" + models.cFree9 + "','" + models.cFree10 + "',NULL,null,0,null,null" +
                                ",null,null,0,null,null,'10','',null,null,'" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "if exists( select * from InvPositionSum where cInvCode = '" + models.cInvCode + "' and cWhCode = '" + model.cWhCode + "' and cPosCode = " + models.cPosition + " and ISNULL(cBatch,'') = '" + models.cBatch + "' " +
                            "and isnull(cFree1,'') = '" + models.cFree1 + "'  and ISNULL(cFree2,'') = '" + models.cFree2 + "' and ISNULL(cFree3,'') = '" + models.cFree3 + "' and ISNULL(cFree4,'') = '" + models.cFree4 + "' and ISNULL(cFree5,'') = '" + models.cFree5 + "' and ISNULL(cFree6,'') = '" + models.cFree6 + "' and ISNULL(cFree7,'') = '" + models.cFree7 + "' and ISNULL(cFree8,'') = '" + models.cFree8 + "' and ISNULL(cFree9,'') = '" + models.cFree9 + "' and ISNULL(cFree10,'') = '" + models.cFree10 + "') " +
                            "   update InvPositionSum set iQuantity = iQuantity +  " + models.iQuantity + ",iNum =NULL where cInvCode = '" + models.cInvCode + "' and cWhCode = '" + model.cWhCode + "' and cPosCode = " + models.cPosition + " and ISNULL(cBatch,'') = '" + models.cBatch + "' " +
                            " and isnull(cFree1,'') = '" + models.cFree1 + "'  and ISNULL(cFree2,'') = '" + models.cFree2 + "' and ISNULL(cFree3,'') = '" + models.cFree3 + "' and ISNULL(cFree4,'') = '" + models.cFree4 + "' and ISNULL(cFree5,'') = '" + models.cFree5 + "' and ISNULL(cFree6,'') = '" + models.cFree6 + "' and ISNULL(cFree7,'') = '" + models.cFree7 + "' and ISNULL(cFree8,'') = '" + models.cFree8 + "' and ISNULL(cFree9,'') = '" + models.cFree9 + "' and ISNULL(cFree10,'') = '" + models.cFree10 + "' " +
                            "else " +
                            "insert InvPositionSum(cWhCode, cPosCode, cInvCode, iQuantity, inum, cBatch, cFree1, cFree2, cFree3" +
                                " , cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10, iTrackid, cvmivencode, cMassUnit" +
                                ", iMassDate, dMadeDate, dVDate, iExpiratDateCalcu, cExpirationdate, dExpirationdate, cInVouchType) " +
                            "values(  '" + model.cWhCode + "', '" + models.cPosition + "', '" + models.cInvCode + "',  " + models.iQuantity + ",  NULL, '" + models.cBatch + "','" + models.cFree1 + "', '" + models.cFree2 + "', '" + models.cFree3 + "'" +
                                " , '" + models.cFree4 + "', '" + models.cFree5 + "', '" + models.cFree6 + "',' " + models.cFree7 + "', '" + models.cFree8 + "', '" + models.cFree9 + "',' " + models.cFree10 + "', '0', null, null" +
                                ", null, null, null, 0, null, null, '')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (!b��Ʒ�������޸��ִ���)
                        {
                            decimal dNum = TH.BaseClass.BaseFunction.ReturnDecimal(models.iNum);

                            sSQL = @"
declare @itmeid int 
select @itmeid = MAX(ItemId) + 1 from CurrentStock 
if exists(select * from CurrentStock where cinvcode = '111111' and cWhCode = '222222' and cFree1 = '555555' and cBatch = '666666')
   update CurrentStock set iQuantity = isnull(iQuantity,0) + 333333,iNum = isnull(iNum,0) + 444444
   where cinvcode = '111111'  and cWhCode = '222222' and cFree1 = '555555' and cBatch = '666666'
else
   insert into CurrentStock(cWhCode,cInvCode,iQuantity,iNum,ItemId,cFree1,cBatch)  
   values('222222', '111111',333333,444444,@itmeid,'555555','666666')
                       ";
                            sSQL = sSQL.Replace("111111", models.cInvCode);
                            sSQL = sSQL.Replace("222222", model.cWhCode);
                            sSQL = sSQL.Replace("333333", models.iQuantity.ToString());
                            sSQL = sSQL.Replace("444444", dNum.ToString());
                            sSQL = sSQL.Replace("555555", models.cFree1);
                            sSQL = sSQL.Replace("666666", models.cBatch);

                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            decimal dNum = TH.BaseClass.BaseFunction.ReturnDecimal(models.iNum);

                            sSQL = @"
declare @itmeid int 
select @itmeid = MAX(ItemId) + 1 from CurrentStock 
if exists(select * from CurrentStock where cinvcode = '111111' and cWhCode = '222222' and cFree1 = '555555' and cBatch = '666666')
   update CurrentStock set fInQuantity = isnull(fInQuantity,0) + 333333,fInNum = isnull(fInNum,0) + 444444
   where cinvcode = '111111'  and cWhCode = '222222' and cFree1 = '555555' and cBatch = '666666'
else
   insert into CurrentStock(cWhCode,cInvCode,fInQuantity,fInNum,ItemId,cFree1,cBatch)  
   values('222222', '111111',333333,444444,@itmeid,'555555','666666')
                       ";
                            sSQL = sSQL.Replace("111111", models.cInvCode);
                            sSQL = sSQL.Replace("222222", model.cWhCode);
                            sSQL = sSQL.Replace("333333", models.iQuantity.ToString());
                            sSQL = sSQL.Replace("444444", dNum.ToString());
                            sSQL = sSQL.Replace("555555", models.cFree1);
                            sSQL = sSQL.Replace("666666", models.cBatch);

                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        sSQL = "insert into IA_ST_UnAccountVouch10(idun,idsun,cvoutypeun,cbustypeun)values " +
                            "('" + lID + "','" + lIDDetails + "','10','��Ʒ���')";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();

                    gridControl1.DataSource = null;

                    txtcCode.Text = model.cCode;

                    MessageBox.Show("����ɹ�");
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����ʧ�ܣ�" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal dNum = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiNum));
                if (dNum != 0)
                {
                    decimal dQuantity = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantity));
                    decimal dUnQty = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColUniQty));
                    decimal dUnNum = TH.BaseClass.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColUniNum));

                    if (radio����Ϊ��.Checked)
                    {
                        dUnQty = TH.BaseClass.BaseFunction.ReturnDecimal(dUnNum * dQuantity / dNum);
                        gridView1.SetRowCellValue(e.RowHandle, gridColUniQty, dUnQty);
                    }
                    if (radio����Ϊ��.Checked)
                    {
                        dUnNum = TH.BaseClass.BaseFunction.ReturnDecimal(dNum * dUnQty / dQuantity);
                        gridView1.SetRowCellValue(e.RowHandle, gridColUniNum, dUnNum);
                    }
                }
            }
            catch { }
        }

    }
}