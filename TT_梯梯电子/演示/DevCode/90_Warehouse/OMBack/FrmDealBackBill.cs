using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace Warehouse
{
    public partial class FrmDealBackBill : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable DTSource = new DataTable();
        ArrayList aList = new ArrayList();
        string Sql = "";
        
        public FrmDealBackBill()
        {
            InitializeComponent();
        }


        private void FormDealBackBill_Load(object sender, EventArgs e)
        {
            InitDataSource();
            InitWH();
        }

        private void InitWH()
        {
            string sql = "select cWhCode ,cWhName  from dbo.Warehouse order by cWhCode ";
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];

            LookUpWH.DataSource = dt;

        }

        private void InitDataSource()
        {
            Sql  = @"select B.BillID,d.MODetailsID ,
                            M.cCode ,
                            v.cVenCode ,
                            v.cVenName ,
                            I.cInvCode ,
                            I.cInvName ,
                            I.cInvAddCode ,
                            I.cInvStd ,
                            D.iQuantity ,
                            d.iUnitPrice ,
                            d.iMoney ,
                            d.dStartDate ,
                            d.dArriveDate ,
                            B.BackQty,
                            B.IsGenRdForm
                    from    UFDLImport.dbo.Bac_OMBack B
                            left join OM_MODetails D on B.OMDId = d.MODetailsID
                            left join dbo.OM_MOMain M on d.MOID = m.MOID
                            left join dbo.Vendor V on M.cVenCode = V.cVenCode
                            left join dbo.Inventory I on D.cInvCode = I.cInvCode
                    where   1=1
                    ";

            string sql = Sql.Replace("1=1", "1=-1");
            DTSource = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];

        }

        private void GetBackDetailByBarCode()
        {
            string barCode = txtBarCode.Text;
            if (barCode == "")
                return;
            string  backId = (barCode.Split('$'))[0];
            DataRow[] rows = DTSource.Select("BillId=" + backId);
            if (rows.Length > 0)
            {
                MessageBox .Show ("列表中已存在该条码,对应的委外单："+rows[0]["cCode"].ToString (),"提示",MessageBoxButtons .OK, MessageBoxIcon .Error );
                txtBarCode.Text = "";
                return ;
            }
            string sql = Sql.Replace("1=1", "BillID=" + backId);
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有对应的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dt.Rows[0]["IsGenRdForm"].ToString() == "True")
            {
                MessageBox.Show("该委外单:" + dt.Rows[0]["cCode"].ToString() + "已经退货", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow row = dt.Rows[0];
            DTSource.ImportRow(row);
            txtBarCode.Text = "";
            grdDetail.DataSource = DTSource;
        }


        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "genrd":
                        GenRdRecords();
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

        private void GenRdRecords()
        {
            FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
            grvDetail.PostEditor();
            this.Validate();

            string whCode = "01";
            string sSQL = "select * from @u8.GL_mend where iperiod = month('" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "')";
            DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
            if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
            {
                MessageBox.Show("当月库存管理已结帐！");
                return;
            }

      
            string filter = "";
            for (int i = 0; i < grvDetail.RowCount; i++)
            {
                string  billId = grvDetail.GetRowCellValue(i, colBillId).ToString ();
                filter += billId + ",";
            }
            filter += "-1";

            string sql = @"select v.cVenCode , I.cInvCode ,sum(b.BackQty) as BackQty
                        from    UFDLImport.dbo.Bac_OMBack B
                                left join OM_MODetails D on B.OMDId = d.MODetailsID
                                left join dbo.OM_MOMain M on d.MOID = m.MOID
                                left join dbo.Vendor V on M.cVenCode = V.cVenCode
                                left join dbo.Inventory I on D.cInvCode = I.cInvCode
                        where   b.BillID in ({0})
                        group by v.cVenCode , I.cInvCode ";
            sql = string.Format(sql, filter);
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables[0];
            if (dt.Rows.Count == 0)
                return;

            SqlConnection conn = new SqlConnection(Assistanter.U8ConnectString);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            string deptCode ="";

            int fatherId = 0;
            int childId = 0;
            string[] u8DBArrs= FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Split ('_');
            string accId=u8DBArrs [1];
            Assistanter.GetIndentityId(Assistanter.U8ConnectString, accId, "rd", dt.Rows.Count, out fatherId, out  childId);
            DateTime serverTime=Assistanter .GetServerTime ();
            try
            {
                string cCode=Assistanter.GetVouchNumber( "0412", "日期", "月", "yyyyMM", 5);

                sql = @"
                            insert into dbo.RdRecord 
                                    ( 
                                    ID,
                                    bRdFlag,
                                    cVouchType,
                                    cBusType,
                                    cSource,
                                    cWhCode,
                                    dDate,
                                    cRdCode,
                                    cMaker,
                                    bpufirst,
                                    biafirst,
                                    VT_ID,
                                    bIsSTQc,
                                    bOMFirst,
                                    bIsComplement,
                                    iswfcontrolled,
                                    cDepCode,
                                    dnmaketime,
                                    cMemo,
                                    bmotran,
                                    cCode
                                    )
                            values  (
		                            '{0}',
                                     0,--bRdFlag,
                                    '11',--cVouchType,
                                    '领料',--cBusType,
                                    '库存',--cSource,
                                    '{6}',--cWhCode,
                                    '{1}',    --dDate,
                                    '21',--cRdCode,
                                    '{2}',--cMaker,
                                    0,--bpufirst,
                                    0,--biafirst,
                                    30768,--VT_ID,
                                    0,--bIsSTQc,
                                    0,--bOMFirst,
                                    0,--bIsComplement,
                                    0,--iswfcontrolled,
                                    null,--cDepCode,
                                    getdate(),--dnmaketime,
                                    '{4}',--cMemo,
                                    0,--bmotran
                                    '{5}'
                    )";
                sql = string.Format(sql,
                    fatherId,
                    serverTime.ToString("yyyy-MM-dd"),
                    FrameBaseFunction.ClsBaseDataInfo.sUid,
                    deptCode,
                    "",
                    cCode ,
                    whCode
                    );

                SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql);

                int loop = 1;
                foreach (DataRow row in dt.Rows)
                {
                    int currChildId = childId - (dt.Rows.Count - loop);
                    loop++;
                    string invCode = row["cInvCode"].ToString();
                    string qty = row["BackQty"].ToString();
                    sql = @"
                        insert into dbo.RdRecords 
                        ( 
	                        AutoID ,
	                        ID ,
	                        cInvCode ,
	                        iNum ,
	                        iQuantity ,
	                        iUnitCost ,
	                        iPrice ,
	                        iPUnitCost,
	                        iPPrice
                        )
                        values  (
	                        {0},--AutoID ,
	                        {1},--ID ,
	                        '{2}',--cInvCode ,
	                        {3},--iNum ,
	                        0-{4},--iQuantity ,
	                        {5},--iUnitCost ,
	                        {6},--iPrice ,
	                        {7},--iPUnitCost,
	                        {8}--iPPrice 
                    )
                    ";
                    sql = string.Format(sql,
                       currChildId,
                       fatherId,
                        invCode,
                        "0",
                        qty,
                        "0",
                        "0",
                        "0",
                        "0");
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql);


                    sql = "if exists(select * from  CurrentStock where cInvCode = '" + invCode  + "' and cWhCode = '" + whCode  + "') " +
                            "	update  CurrentStock set iQuantity = isnull(iQuantity,0) + " + qty + "  where cInvCode = '" + invCode  + "' and cWhCode = '" + whCode  + "' " +
                                  "else " +
                                      "begin " +
                                      "    declare @itemid varchar(20); " +
                                      "declare @iCount int;  " +
                                        "select @iCount=count(itemid) from CurrentStock where cInvCode = '" +invCode + "';   " +
                                        "if( @iCount > 0 ) " +
                                        "	select @itemid=itemid from CurrentStock where cInvCode = '" + invCode + "';  " +
                                        "else  " +
                                        "	 select @itemid=max(itemid+1) from CurrentStock  " +
                                        "    insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + whCode + "','" + invCode  + "'," + qty  + ",@itemid) " +
                                      "end";
                    SqlHelper.ExecuteNonQuery(trans, CommandType.Text, sql);

                }

                sql = "update dbo.Bac_OMBack  set IsGenRdForm =1 where BillID in ({0})";
                sql = string.Format(sql, filter);
                clsSQLCommond.ExecSql (sql);
                trans.Commit();
                DTSource.Clear();
                grdDetail.DataSource = DTSource;
                MessageBox.Show("完成","提示",MessageBoxButtons.OK ,MessageBoxIcon.Information  );
            }
            catch(Exception error)
            {
                trans.Rollback();
                MessageBox.Show("发生错误:\n" + error.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            trans = null;
            conn.Close();
            conn = null;
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBarCode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetBackDetailByBarCode();
            }
            e.Handled = false;

        }


    }
}
