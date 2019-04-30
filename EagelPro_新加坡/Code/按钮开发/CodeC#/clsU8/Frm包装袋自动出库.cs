using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clsU8
{
    public partial class Frm包装袋自动出库 : Form
    {
        
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;


        public Frm包装袋自动出库()
        {
            InitializeComponent();
        }

        private void Frm包装袋自动出库_Load(object sender, EventArgs e)
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(sConnString) == false)
                {
                    throw new Exception("加载数据失败");
                }

                string sSQL = "select getdate()";
                DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                dateEdit1.DateTime = dNow;

                label4.Text = dNow.ToString("yyyy-MM-dd HH:mm:ss");

                sSQL = "select cRdCode,cRdName from Rd_Style where bRdEnd = 1 and bRdFlag = 0 order by cRdCode";
                DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                lookUpEditOutType.Properties.DataSource = dt;
                lookUpEditOutType.EditValue = "D99";

                sSQL = "select cWhCode,cWhName from warehouse order by cWhCode";
                dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                lookUpEditWarehouse.Properties.DataSource = dt;
                lookUpEditWarehouse.EditValue = "W1";

                sSQL = @"
select a.cPOID,b.cInvCode,c.cInvName,c.cInvStd,d.cInvCode as cInvCode2,e.cInvName as cInvName2,e.cInvStd as cInvStd2
    ,cast(b.iQuantity as decimal(16,0)) as Qty,cast(f.iQuantity as decimal(16,0)) as CurrQty
    
    ,b.ID
from PO_Pomain a inner join PO_Podetails b on a.POID = b.POID
	inner join Inventory c on b.cInvCode = c.cInvCode
	left join
	(
		select c.InvCode, e.InvCode as cInvCode
		from bom_bom a inner join bom_parent b on a.bomid = b.bomid
			inner join bas_part c on b.ParentId = c.partid
			inner join bom_opcomponent d on d.bomid = a.bomid
			inner join bas_part e on e.Partid = d.ComponentId 
	)d on b.cInvCode = d.InvCode
	left join Inventory e on e.cInvCode = d.cInvCode
	left join 
	(
		select sum(iQuantity) as iQuantity,cWhCode ,cInvCode
		from CurrentStock 
        where cWhCode = '222222'
		group by cWhCode ,cInvCode
	)f on f.cInvCode = e.cInvCode 
where a.cPOID = '111111'
	and isnull(d.cInvCode,'') <> ''
order by b.ID
";
                sSQL = sSQL.Replace("111111", s单据号);
                if (lookUpEditWarehouse.EditValue != null && lookUpEditWarehouse.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("222222", lookUpEditWarehouse.EditValue.ToString().Trim());
                }

                dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dt;

                //if (sLogDate != "")
                //{
                //    dateEdit1.DateTime = BaseFunction.ReturnDate(sLogDate);
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        public Frm包装袋自动出库(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server=" + s服务器 + ";uid=" + sSA + ";pwd= " + sPwd + ";database=" + s数据库 + ";timeout=200";
        }


        private void btn取消_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    string s采购订单号 = gridView1.GetRowCellValue(0, gridColcPOID).ToString().Trim();
                    sSQL = @"
select a.cPOID 
from PO_PoMain a inner join PO_Podetails b on a.POID = b.POID
	inner join  RdRecord09 c on b.cDefine33 = c.cCode
	and a.cPOID = '111111'
";
                    sSQL = sSQL.Replace("111111", s采购订单号);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        throw new Exception("Packing bag has been out of the warehouse");
                    }

                    sSQL = "select isnull(bflag_ST,0) as bflag_ST from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";     
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Access module state failure");
                    }
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag_ST"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " have checked out");
                    }  

                    int iCouRow = gridView1.RowCount;

                    DateTime dLog = dateEdit1.DateTime;
                    DateTime sLogDate = dateEdit1.DateTime;

                    //获得单据号
                    sSQL = "select cNumber from VoucherHistory Where CardNumber='0302'";        // and cSeed = '" + dLog.ToString("yyyyMM") + "'
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                        lCode += 1;
                        sSQL = "update  VoucherHistory set cNumber = '" + lCode.ToString() + "' Where CardNumber='0302'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        lCode = 1;
                        sSQL = "insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)" +
                                "values('0302',null,null,null,'1',0)";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    string sCode = lCode.ToString();
                    while (sCode.Length < 10)
                    {
                        sCode = "0" + sCode;
                    }


                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=111111
declare @p6 int
set @p6=222222
exec sp_GetId N'',N'003',N'rd',333333,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("111111", lID.ToString());
                    sSQL = sSQL.Replace("222222", lIDDetails.ToString());
                    sSQL = sSQL.Replace("333333", iCouRow.ToString());
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - iCouRow;

                    TH.clsU8.Model.RdRecord09 model = new TH.clsU8.Model.RdRecord09();
                    lID +=1;
                    model.ID = lID;
                    model.bRdFlag = 0;
                    model.cVouchType = "09";
                    model.cBusType = "其他出库";
                    model.cSource = "库存";
                    //model.cBusCode 
                    model.cWhCode = lookUpEditWarehouse.EditValue.ToString().Trim();
                    model.dDate = BaseFunction.ReturnDate(dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                    model.cCode = sCode;
                    model.cRdCode = lookUpEditOutType.EditValue.ToString().Trim();
                    //model.cDepCode 
                    //model.cPersonCode
                    //model.cPTCode
                    //model.cSTCode
                    //model.cCusCode 
                    //model.cVenCode
                    //model.cOrderCode
                    //model.cARVCode
                    //model.cBillCode
                    //model.cDLCode
                    //model.cProBatch
                    model.bTransFlag = false;
                    model.bpufirst = false;
                    model.biafirst = false;
                    model.VT_ID = 85;
                    model.bIsSTQc = false;
                    model.bFromPreYear = false;
                    model.bIsComplement = 0;
                    model.iDiscountTaxType = 0;
                    model.iBG_OverFlag = 0;
                    model.dnmaketime = DateTime.Now;
                    model.bredvouch = 0;
                    model.iPrintCount = 0;
                    model.csysbarcode = "||st09|" + sCode;
                    model.cMaker = sUserName;
                    model.cDefine1 = s采购订单号;
                    model.cHandler = sUserName;
                    model.dVeriDate = BaseFunction.ReturnDate(DateTime.Now.ToString("yyyy-MM-dd"));
                    model.dnverifytime = DateTime.Now;

                    TH.clsU8.DAL.RdRecord09 dal = new TH.clsU8.DAL.RdRecord09();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    int iRow = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string scInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                        string scInvCode2 = gridView1.GetRowCellValue(i, gridColcInvCode2).ToString().Trim();

                        if (scInvCode2 == "")
                        {
                            sErr = sErr + "Item Code " + scInvCode + " no set\n";
                            continue;
                        }

                        decimal dQty = clsU8.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(i, gridColQty), 2);

                        string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode2).ToString().Trim();
                        sSQL = "select cInvCode,cWhCode,iQuantity as iQty,cWhCode,isnull(cBatch,'') as cBatch from currentstock   where cInvCode = '" + sInvCode + "' and cWhCode = '" + model.cWhCode + "' order by cBatch";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dQty <= 0)
                                break;

                            string sBatch = dt.Rows[j]["cBatch"].ToString().Trim();
                            decimal dCurrQtyRow = BaseFunction.ReturnDecimal(dt.Rows[j]["iQty"], 2);

                            if (dCurrQtyRow <= 0)
                                continue;

                            decimal dOutRow  = 0;
                            if (dCurrQtyRow >= dQty)
                            {
                                dOutRow = dQty;
                                dQty = 0;
                            }
                            else
                            {
                                dOutRow = dCurrQtyRow;
                                dQty = dQty - dCurrQtyRow;
                            }

                            TH.clsU8.Model.rdrecords09 models = new TH.clsU8.Model.rdrecords09();

                            lIDDetails += 1;
                            models.AutoID = lIDDetails;
                            models.ID = lID;
                            models.cInvCode = sInvCode;
                            models.iQuantity = dOutRow;
                            models.cBatch = sBatch;
                            models.iFlag = 0;
                            models.bLPUseFree = false;
                            models.iRSRowNO = 0;
                            models.iOriTrackID = 0;
                            models.bCosting = true;
                            models.bVMIUsed = false;
                            models.iExpiratDateCalcu = 0;
                            models.iordertype = 0;
                            models.isotype = 0;
                            models.irowno = iRow;

                            iRow += 1;
                            models.cbsysbarcode = "||st09|" + sCode + "|" + (iRow + 1).ToString();



                            TH.clsU8.DAL.rdrecords09 dals = new TH.clsU8.DAL.rdrecords09();
                            sSQL = dals.Add(models);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = "update PO_Podetails set cDefine34 = " + models.iQuantity.ToString() + ",cDefine33 = '" + model.cCode + "' where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString();
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            if (sBatch == "")
                            {
                                sSQL = "update currentstock set iQuantity = iQuantity - " + models.iQuantity.ToString().Trim() + " where cInvCode = '" + models.cInvCode + "' and cWhCode = '" + model.cWhCode + "' and isnull(cBatch,'') =''";
                            }
                            else

                                sSQL = "update currentstock set iQuantity = iQuantity - " + models.iQuantity.ToString().Trim() + " where cInvCode = '" + models.cInvCode + "' and cWhCode = '" + model.cWhCode + "' and isnull(cBatch,'') = '" + sBatch + "'";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    
                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }
                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n" + sCode);
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
    }
}
