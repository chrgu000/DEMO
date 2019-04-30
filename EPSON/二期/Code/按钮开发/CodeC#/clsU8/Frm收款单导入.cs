using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace clsU8
{
    public partial class Frm收款单导入 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;

        public Frm收款单导入()
        {
            InitializeComponent();
        }


        public Frm收款单导入(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }
    
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2010|*.xlsx|Excel2003|*.xls|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [Sheet1$]";

                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string sColName = dt.Columns[i].ColumnName;
                    sColName = sColName.Replace(" ", "");
                    sColName = sColName.Replace(".", "");
                    sColName = sColName.Replace("#", "");

                    dt.Columns[i].ColumnName = sColName;
                }

                gridControl1.DataSource = dt;

                gridView1.BestFitColumns();

                chkAll.Checked = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    ////获得单据号
                    //sSQL = "select max(cNumber) as Maxnumber From VoucherHistory  with (ROWLOCK)  Where  CardNumber='RR' and cContent is NULL";
                    //dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //long lCode = 0;
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    lCode = BaseFunction.ReturnLong(dt.Rows[0]["Maxnumber"]);
                    //}
                    //else
                    //{
                    //    lCode = 0;
                    //}

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'SK',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", 1.ToString());
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    ArrayList aList = new ArrayList();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if(!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridColchoose)))
                            continue;

                        bool bExists = false;

                        string sDocumentNo = gridView1.GetRowCellValue(i,gridColDocumentNo).ToString().Trim();
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (sDocumentNo == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }
                        if (bExists)
                            continue;

                        aList.Add(sDocumentNo);

                        DateTime dDate = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridColDate));
                        sSQL = "select isnull(bflag_AR,0) as bflag from GL_mend where iYPeriod = '" + dDate.ToString("yyyyMM") + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " access module state failure\n";
                            continue;
                        }
                        int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                        if (i结账 > 0)
                        {
                            sErr = sErr + "Row " + (i + 1).ToString() + " date is err\n";
                            continue;
                        }

                        sSQL = "select count(1) from Ap_CloseBills where isnull(cDefine22,'') = 'aaaaaa'";
                        sSQL = sSQL.Replace("aaaaaa", sDocumentNo);
                        DataTable dtDoc = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtDoc != null && dtDoc.Rows.Count > 0 && BaseFunction.ReturnInt(dtDoc.Rows[0][0]) > 0)
                        {
                            sErr = sErr + "row " + i.ToString() + " Document No. is exists err\n";
                            continue;
                        }
                        
                        //lCode += 1;
                        //string sCode = lCode.ToString();
                        //while (sCode.Length < 10)
                        //{
                        //    sCode = "0" + sCode;
                        //}

                        lID += 1;

                        TH.clsU8.Model.Ap_CloseBill model = new TH.clsU8.Model.Ap_CloseBill();
                        model.cVouchType = "48";

                        model.cVouchID = sDocumentNo;
                        model.dVouchDate = BaseFunction.ReturnDate(dDate.ToString("yyyy-MM-dd"));
                        model.iPeriod = model.dVouchDate.Month - 3;
                        if (model.iPeriod <= 0)
                        {
                            model.iPeriod = model.iPeriod + 12;
                        }

                        sSQL = "select * from Customer where isnull(cCusDefine2,'') = '" + gridView1.GetRowCellValue(i, gridColGMCVCode).ToString().Trim() + "'";
                        DataTable dtCus = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtCus == null || dtCus.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + i.ToString() + "GMCV Code  is not exists err\n";
                            continue;
                        }
                        model.cDwCode = dtCus.Rows[0]["cCusCode"].ToString().Trim();
                        model.cSSCode = "1";        //需要默认值

                        sSQL = "select * from foreigncurrency where cexch_name = 'aaaaaa' or cexch_code = 'aaaaaa'";
                        sSQL = sSQL.Replace("aaaaaa", gridView1.GetRowCellValue(i, gridColCurency).ToString().Trim());
                        DataTable dtForeigncurrency = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtForeigncurrency == null || dtForeigncurrency.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + i.ToString() + "Curency is not exists err\n";
                            continue;
                        }
                        model.cexch_name = dtForeigncurrency.Rows[0]["cexch_name"].ToString().Trim();
                        model.iExchRate = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColExchangeRate));
                        if (model.iExchRate == 0)
                        {
                            sErr = sErr + "row " + i.ToString() + " Please set Exchange Rate\n";
                            continue;
                        }
                        model.cOperator = sUserName;
                        model.bPrePay = false;
                        model.bStartFlag = false;
                        model.iPayForOther = false;
                        model.cFlag = "AR";
                        model.bSend = false;
                        model.bReceived = false;
                        model.iID = lID;
                        model.bFromBank = false;
                        model.bToBank = false;
                        model.bSure = false;
                        model.VT_ID = 8052;
                        model.iAmount = 0;
                        model.IsWfControlled = false;
                        model.RegisterFlag = 0;
                        model.dcreatesystime = DateTime.Now;
                        model.ibg_ctrl = false;
                        model.ibg_ctrl = false;
                        model.iPrintCount = 0;
                        model.iPayForOther = false;
                        model.iAmount_s = 0;

                        decimal d本币 = 0;
                        decimal d原币 = 0;

                        ArrayList aListDetails = new ArrayList();
                        for (int j = i; j < gridView1.RowCount; j++)
                        {
                            string sDocumentNo2 = gridView1.GetRowCellValue(j, gridColDocumentNo).ToString().Trim();
                            if (sDocumentNo != sDocumentNo2)
                            {
                                continue;
                            }

                            TH.clsU8.Model.Ap_CloseBills models = new TH.clsU8.Model.Ap_CloseBills();
                            models.iID = model.iID;

                            lIDDetails +=1;
                            models.ID = lIDDetails;
                            models.iType = 0;
                            models.bPrePay = false;
                            models.cCusVen = model.cDwCode;
                            models.iAmt_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColOriginal));
                            models.iRAmt_f = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColOriginal));
                            d原币 = d原币 + models.iAmt_f;

                            models.iAmt = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColLocalAMT));
                            models.iRAmt = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridColLocalAMT));
                            d本币 = d本币 + models.iAmt;

                            models.iAmt_s = 0;
                            models.RegisterFlag = 0;
                            models.iSrcClosesID = 0;
                            models.ifaresettled_f = 0;
                            models.cMemo = gridView1.GetRowCellValue(j, gridColDiscription).ToString().Trim();
                            models.cDefine22 = gridView1.GetRowCellValue(j, gridColDocumentNo).ToString().Trim();
                            models.cDefine23 = gridView1.GetRowCellValue(j, gridColInvoiceNo).ToString().Trim();
                            models.iRAmt_s = 0;

                            TH.clsU8.DAL.Ap_CloseBills dals = new TH.clsU8.DAL.Ap_CloseBills();
                            sSQL = dals.Add(models);
                            aListDetails.Add(sSQL);
                        }
                        model.iAmount = d本币;
                        model.iAmount_f = d原币;
                        model.iRAmount = d本币;
                        model.iRAmount_f = d原币;

                        TH.clsU8.DAL.Ap_CloseBill dal = new TH.clsU8.DAL.Ap_CloseBill();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int ii = 0; ii < aListDetails.Count; ii++)
                        {
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, aListDetails[ii].ToString());
                        }
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'SK'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                    sSQL = @"
//if exists(select * from VoucherHistory where CardNumber='RR' and cContent is NULL)
//	update VoucherHistory set cNumber = aaaaaa  where CardNumber='RR' and cContent is NULL
//else
//	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
//	values('RR',null,null,null,'aaaaaa',0)
//";
//                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
//                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");
                    }
                    else
                    {
                        throw new Exception("Save failed");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
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
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
                }
            }
            catch { }
        }
    }
}
