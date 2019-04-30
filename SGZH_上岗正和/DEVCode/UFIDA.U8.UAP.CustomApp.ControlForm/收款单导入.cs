using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using System.Data.OracleClient;
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class 收款单导入 : UserControl
    {

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 收款单导入()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.结算方式编码=b.cSSCode";
                DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit结算方式.DataSource = dt;

                dateEdit结束日期.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit开始日期.EditValue = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-01";

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "加载数据失败");
            }
        }


        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

                string sErr = "";
                string sSQL = "";

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                Config oconfig = new Config();
                OracleConnection ocon = new OracleConnection(oconfig.ConnectionString);
                OracleCommand ocmd = new OracleCommand();
                OracleTransaction otrans;
                ocon.Open();
                ocmd.Connection = ocon;
                otrans = ocon.BeginTransaction();
                ocmd.Transaction = otrans;

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        if (dtGrid.Rows[i]["选择"].ToString().Trim() == "True")
                        {
                            sSQL = "select count(1) from ERP_IMPORT_AP where 收款单ID = '" + dtGrid.Rows[i]["收款单ID"].ToString().Trim() + "' and  发票ID = '" + dtGrid.Rows[i]["发票ID"].ToString().Trim() + "' ";
                            int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou1 > 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据号已导入\n";
                                continue;
                            }

                            sSQL = "select count(1) from Ap_CloseBill where cDefine15  = '" + dtGrid.Rows[i]["收款单ID"].ToString().Trim() + "' ";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou > 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据号已存在\n";
                                continue;
                            }


                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "SELECT * FROM UFSystem..UA_Identity where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
                    DataTable dtID = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID = 0;
                    long lIDMain = 0;
                    long lIDDetails = 0;
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lID = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iFatherId"]);
                        lIDDetails = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iChildId"]);
                    }

                    int scount = 0;
                    int ocount = 0;

                    sSQL = "SELECT max(cVouchID) as cVouchID,max(Auto_ID) as Auto_ID FROM  Ap_Vouch";
                    DataTable dtAp_Vouch = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lvcode = 0;
                    long lvid=0;
                    if (dtAp_Vouch.Rows.Count > 0)
                    {
                        lvcode = SqlHelper.ReturnObjectToLong(dtAp_Vouch.Rows[0]["cVouchID"]);
                        lvid = SqlHelper.ReturnObjectToLong(dtAp_Vouch.Rows[0]["Auto_ID"]);
                    }

                    sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='RR' and cContent is NULL";
                    DataTable dtcode = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long code = 0;
                    if (dtcode.Rows.Count > 0)
                    {
                        code = SqlHelper.ReturnObjectToLong(dtcode.Rows[0][0]);
                    }
                    
                    DataTable dtgroup = Group(dtGrid, new string[] { "收款单ID", "客户编码", "单据日期", "币种", "付费方式2", "结算科目", "汇率" }, "选择='True'");
                    for (int j = 0; j < dtgroup.Rows.Count; j++)
                    {

                        #region 数据验证

                        sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt结账状态 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d结账 = Convert.ToDateTime(dt结账状态.Rows[0]["iyear"].ToString().Trim() + "-" + dt结账状态.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d结账 > SqlHelper.ReturnObjectToDateTime(dtgroup.Rows[j]["单据日期"]))
                        {
                            sErr = sErr + "该单据日期"+dtgroup.Rows[j]["单据日期"]+"应收模块已结账\n";
                            continue;
                        }

                        string s客户 = dtgroup.Rows[j]["客户编码"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s客户 + "' or cCusName = '" + s客户 + "' or cCusAbbName = '" + s客户 + "'";
                        DataTable dt客户 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt客户 == null || dt客户.Rows.Count < 1)
                        {
                            sErr = sErr +  "客户" + s客户 + "不存在\n";
                            continue;
                        }
                        if (dt客户.Rows.Count > 1)
                        {
                            sErr = sErr + "客户" + s客户 + "存在多个定义,请使用客户编码唯一指定\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtgroup.Rows[j]["币种"].ToString().Trim() + "' or cexch_name = '" + dtgroup.Rows[j]["币种"].ToString().Trim() + "'";
                        DataTable dt币种 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt币种.Rows.Count == 0)
                        {
                            sErr = sErr + "币种" + dtgroup.Rows[j]["币种"].ToString().Trim() + "不存在\n";
                            continue;
                        }

                        string 结算方式 = dtgroup.Rows[j]["付费方式2"].ToString().Trim();
                        if (结算方式 == "")
                        {
                            sErr = sErr + "收款单" + dtgroup.Rows[j]["收款单ID"]  + "的结算方式为空\n";
                        }
                        //sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.结算方式编码=b.cSSCode where 业务系统编码 = '" + dtgroup.Rows[j]["付费方式"].ToString().Trim() + "'";
                        //DataTable dt结算方式 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //if (dt结算方式.Rows.Count == 0)
                        //{
                        //    sErr = sErr + "结算方式" + dtgroup.Rows[j]["付费方式"].ToString().Trim() + "不存在\n";
                        //    continue;
                        //}
                        //else
                        //{
                        //    结算方式 = dt结算方式.Rows[0]["cSSCode"].ToString().Trim();
                        //}


                        #endregion

                        #region 导入表头数据

                        decimal 核销金额 = 0;
                        decimal 汇率 = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["汇率"]);
                        decimal 外币核销金额 = 0;

                        string icode = "";
                        string ivcode = "";
                        if (结算方式 != "5")
                        {
                            //cVouchType 48  表示收款单
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            code += 1;
                            icode = sGetCode(code, 10);

                            sSQL = @"Insert Into Ap_CloseBill (cVouchType,cVouchID,dVouchDate,iPeriod,cDwCode,cDeptCode,cPerson,cItem_Class,cSSCode,cNoteNo
                                                            ,cCoVouchType,cCoVouchID,cBankAccount,cexch_name,iExchRate
                                                            ,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator
                            
                                                            ,cCancelMan,bStartFlag,cCode,iPayForOther,cFlag,iID,cCancelNo,cBank,bFromBank,bToBank
                                                            ,bSure,VT_ID,cCheckMan,iAmount_s,iSource,dcreatesystime,dverifysystime,dverifydate,cDefine10) " +
                                   "Values (N'48'," + ReturnDBString(icode) + "," + ReturnDBString(dtgroup.Rows[j]["单据日期"]) + "," + Convert.ToDateTime(dtgroup.Rows[j]["单据日期"]).Month + "," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + ",null,null,null," + ReturnDBString(结算方式) + ",null" +
                                            ",null,null," + ReturnDBString(dt客户.Rows[0]["cCusAccount"]) + "," + ReturnDBString(dt币种.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtgroup.Rows[j]["汇率"]) + "," +
                                            "" + 核销金额 + "," + 外币核销金额 + "," + 核销金额 + "," + 外币核销金额 + ",N'" + sUserName + "'" +

                                            ",null,0," + ReturnDBString(dtgroup.Rows[j]["结算科目"]) + ",0,N'AR'," + lIDMain + ",null," + ReturnDBString(dt客户.Rows[0]["cCusBank"]) + ",0,0" +
                                            ",0,8052,null,0,null,GETDATE(),null,null,'Y') ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            //
                            lvcode = lvcode + 1;
                            lvid = lvid + 1;
                            ivcode = sGetCode(lvcode, 10);


                            sSQL = @"INSERT into [Ap_Vouch] ([cLink],[cVouchType],[cVouchID],[dVouchDate],[cDwCode],[cCode],[cexch_name],[iExchRate],[bd_c],
[iAmount],[iAmount_f],[iRAmount],[iRAmount_f],[cOperator],[bStartFlag],[cFlag],[cDefine1],[iAmount_s],[iRAmount_s],
[VT_ID],[Ufts],[iClosesID],[iCoClosesID],[dGatheringDate],[dcreatesystime],[Auto_ID],[iPrintCount]) 
VALUES ( N'R0" + ivcode + "',N'R0',N'" + ivcode + "'," + ReturnDBString(dtgroup.Rows[j]["单据日期"]) + "," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + ",N'2203',N" + ReturnDBString(dt币种.Rows[0]["cexch_name"]) + ",1,1," +
    "" + 核销金额 + "," + 外币核销金额 + "," + 核销金额 + "," + 外币核销金额 + ",N'" + sUserName + "',0,N'AR',null,0,0," +
    "8054,null,0,0,null,'" + DateTime.Now.ToString() + "'," + lvid + ",0)";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        scount = scount + 1;

                        #endregion

                        #region 导入表体数据
                        for (int i = 0; i < dtGrid.Rows.Count; i++)
                        {
                            if (dtGrid.Rows[i]["选择"].ToString().Trim() == "True" 
                                && dtGrid.Rows[i]["收款单ID"].ToString().Trim() == dtgroup.Rows[j]["收款单ID"].ToString().Trim()
                                && dtGrid.Rows[i]["结算科目"].ToString().Trim() == dtgroup.Rows[j]["结算科目"].ToString().Trim()
                                && dtGrid.Rows[i]["单据日期"].ToString().Trim() == dtgroup.Rows[j]["单据日期"].ToString().Trim()
                                && dtGrid.Rows[i]["付费方式2"].ToString().Trim() == dtgroup.Rows[j]["付费方式2"].ToString().Trim())
                            {
                                lIDDetails += 1;
                                decimal s核销金额 = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["核销金额"]);
                                decimal s外币核销金额 = s核销金额 * 汇率;

                                核销金额 = s核销金额 + 核销金额;
                                外币核销金额 = s外币核销金额 + 外币核销金额;

                                if (结算方式 != "5")
                                {
                                    sSQL = "INSERT INTO Ap_CloseBills (iID,ID,iType,bPrePay,cCusVen,iAmt_f,iAmt,iRAmt_f,iRAmt,cKm," +
                                                "cXmClass,cDepCode,iAmt_s,iRAmt_s,iOrderType) " +
                                           "VALUES " +
                                        "(" + lIDMain + "," + ReturnID(lIDDetails) + ",0,0," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + "," + s外币核销金额 + "," + s核销金额 + "," + s外币核销金额 + "," + s核销金额 + "," + ReturnDBString(dtGrid.Rows[i]["贷方科目"]) + "," +
                                                "NULL,NULL,0,0,NULL)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into ERP_IMPORT_AP(发票号码,发票ID,收款单ID,核销单ID,ERP收款单ID,ERP收款单单据号) " +
                                "values(" + ReturnDBString(dtGrid.Rows[i]["发票号码"]) + "," + ReturnDBString(dtGrid.Rows[i]["发票ID"]) + "," + ReturnDBString(dtGrid.Rows[i]["收款单ID"]) + "," + ReturnDBString(dtGrid.Rows[i]["核销单ID"]) + "," +
                                "" + lID + ",'" + icode + "') ";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                else
                                {
                                    sSQL = @"INSERT into [Ap_Vouchs] ([cLink],[cDwCode],[cDigest],[cCode],[cexch_name],[iExchRate],[bd_c],[iAmount],[iAmount_f],[iAmt_s]) 
                                VALUES ( N'R0" + ivcode + "'," + ReturnDBString(dt客户.Rows[0]["cCusCode"]) + ",N''," + ReturnDBString(dtGrid.Rows[i]["贷方科目"]) + ",N" + ReturnDBString(dt币种.Rows[0]["cexch_name"]) + ",1,0," + 核销金额 + "," + 外币核销金额 + ",0)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into ERP_IMPORT_AP(发票号码,发票ID,收款单ID,核销单ID,ERP收款单ID,ERP收款单单据号) " +
                                "values(" + ReturnDBString(dtGrid.Rows[i]["发票号码"]) + "," + ReturnDBString(dtGrid.Rows[i]["发票ID"]) + "," + ReturnDBString(dtGrid.Rows[i]["收款单ID"]) + "," + ReturnDBString(dtGrid.Rows[i]["核销单ID"]) + "," +
                                "" + lID + ",'" + lvcode + "') ";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }
                        }
                        if (结算方式 != "5")
                        {
                            sSQL = "update Ap_CloseBill set iAmount=" + 核销金额 + ",iAmount_f=" + 外币核销金额 + ",iRAmount=" + 核销金额 + ",iRAmount_f=" + 外币核销金额 + " where iID='" + lIDMain + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "update Ap_Vouch set iAmount=" + 核销金额 + ",iAmount_f=" + 外币核销金额 + " where cVouchID='" + ivcode + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update VoucherHistory set cNumber = " + code + " Where  CardNumber='RR' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    otrans.Commit();
                    MessageBox.Show("保存成功,共" + scount + "条");

                    gridControl1.DataSource = null;
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    otrans.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        private long ReturnID(long l)
        {
            long l1 = 1000000000;
            return l1 + l;
        }

        private string GetColValue(object o)
        {
            string s = "null";
            if (o.ToString().Trim() != "")
            {
                s = "'" + o.ToString().Trim() + "'";
            }
            return s;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                string sSQL = @"select a.发票ID,a.核销ID as 核销单ID,a.收款单ID,a.发票号码,发票类型,付费代理,收款单人,收款单时间,收款单银行,收款单金额,收款单帐号,币种,1 as 汇率,船名,航次,付费人,
发票金额,发票税额,核销金额, 付费方式 ,备注,客户代码,付费代理 as 客户编码,开票地点,进出标志,汇率,抵港时间,发票状态,CHB_ARCHIVEFG,
用友核销标志,用友核销人,用友核销时间,用友应收标志,用友应收人,用友应收时间,CHB_RETURN_FLAG,发票打印日期,CHB_TERM_NAME,
CHB_CST_CSTMNM,CHB_IE_NAME,CHB_BANK_NAME,发票送出时间,TO_CHAR(发票收款时间,'yyyy-mm-dd') as 单据日期,BLA_HANDLE_TYPE from CW_RECE_MONEY_VW a left join CW_RECE_BILL_LISTS c on a.收款单ID=c.YRB_REL_ID 
where 1=1 ";

                if (textBox发票ID.Text != "")
                {
                    sSQL = sSQL + " and a.发票ID='" + textBox发票ID.Text.Trim() + "'";
                }
                if (textBox发票号码.Text != "")
                {
                    sSQL = sSQL + " and a.发票号码='" + textBox发票号码.Text.Trim() + "'";
                }
                if (textBox客户.Text != "")
                {
                    sSQL = sSQL + " and 客户名 like '%" + textBox客户.Text.Trim() + "%'";
                }
                if (textBox收款单ID.Text != "")
                {
                    sSQL = sSQL + " and a.收款单ID='" + textBox收款单ID.Text.Trim() + "'";
                }
                if (dateEdit开始日期.Text != "")
                {
                    sSQL = sSQL + " and 发票收款时间>=to_date('" + dateEdit开始日期.DateTime.ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }
                if (dateEdit结束日期.Text != "")
                {
                    sSQL = sSQL + " and 发票收款时间<to_date('" + dateEdit结束日期.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }



                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                sSQL = "select * from ERP_IMPORT_AP";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (rdo未导入.Checked == true)
                    {
                        //sSQL = sSQL + " and c.YRB_REL_ID is  null ";
                        if (dts.Select("收款单ID='" + dt.Rows[i]["收款单ID"].ToString() + "' and 发票ID='" + dt.Rows[i]["发票ID"].ToString() + "'").Length > 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    else
                    {
                        //sSQL = sSQL + " and c.YRB_REL_ID is not null ";
                        if (dts.Select("收款单ID='" + dt.Rows[i]["收款单ID"].ToString() + "' and 发票ID='" + dt.Rows[i]["发票ID"].ToString() + "'").Length == 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }

                }

                dt.Columns.Add("借方科目");
                dt.Columns.Add("贷方科目");
                dt.Columns.Add("结算科目");
                DataColumn dc = new DataColumn();
                dc.ColumnName = "选择";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                bool b = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["贷方科目"] = "1122";

                    dt.Rows[i]["结算科目"] = "10020101";
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }

                dt.Columns.Add("付费方式2");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string 结算方式 = "";
                    sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.结算方式编码=b.cSSCode where 业务系统编码 = '" + dt.Rows[i]["付费方式"].ToString().Trim() + "'";
                    DataTable dt结算方式 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt结算方式.Rows.Count == 0)
                    {
                        //sErr = sErr + "结算方式" + dtGrid.Rows[i]["付费方式"].ToString().Trim() + "不存在\n";
                        //continue;
                    }
                    else
                    {
                        结算方式 = dt结算方式.Rows[0]["cSSCode"].ToString().Trim();
                    }
                    dt.Rows[i]["付费方式2"] = 结算方式;
                }

                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "加载失败";
                f.ShowDialog();
            }
        }


        //根据历史单据生成最新单据号
        private string ReturnCode(DateTime d, long o)
        {
            string s = o.ToString();
            int iLength = 4;

            for (int i = 0; i < iLength; i++)
            {
                if (s.Length < iLength)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }

            s = d.ToString("yyMM") + s;
            return s;
        }

        private string ReturnID(object o)
        {
            string s = o.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (s.Length < 9)
                    s = "0" + s;
                else if (s.Length == 9)
                    s = "1" + s;
                else
                    break;
            }
            return s;
        }

        private string ReturnDBString(decimal o)
        {
            return o.ToString();
        }

        private string ReturnDBString(DateTime o)
        {
            return o.ToString("yyyy-MM-dd");
        }

        private string ReturnDBString(object o)
        {
            if (o.ToString().Trim() == "")
                return "null";
            else
            {
                return "'" + o.ToString().Trim() + "'";
            }
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return sCode;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }



            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetChk(checkEdit1.Checked);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetChk(bool b)
        {
            if (b == false)
            {
                checkEdit1.Text = "全选";
            }
            else
            {
                checkEdit1.Text = "全部取消";
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColChk, b);
            }

        }

        private void ItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit edit = sender as CheckEdit;
                bool b = false;
                if (edit.Checked == true)
                {
                    b = true;
                }

                int iRow = gridView1.FocusedRowHandle;
                string code = gridView1.GetRowCellValue(iRow, gridCol发票号码).ToString().Trim();
                decimal money = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim() == code)
                    {
                        gridView1.SetRowCellValue(i, gridColChk, b);
                    }
                    if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                    {
                        money = money + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol核销金额));
                    }
                }
                txt总金额.Text = money.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }

        private void tsbGet_Click(object sender, EventArgs e)
        {
            try
            {
                Config oconfig = new Config();
                OracleConnection ocon = new OracleConnection(oconfig.ConnectionString);
                OracleCommand ocmd = new OracleCommand();
                OracleTransaction otrans;
                ocon.Open();
                ocmd.Connection = ocon;
                otrans = ocon.BeginTransaction();
                ocmd.Transaction = otrans;

                try
                {
                    string sSQL = @"select a.发票号码,a.发票ID,a.收款单ID,核销ID as 核销单ID from CW_RECE_MONEY_VW a 
left join CW_RECE_BILL_LISTS c on a.收款单ID=c.YRB_REL_ID  where c.YRB_REL_ID is  null";
                    DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                    SqlConnection conn = new SqlConnection(Conn);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();

                    sSQL = @"select cVouchID,cPZNum,b.cbill,b.dbill_date,收款单ID from Ap_CloseBill a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_AP c on a.cVouchID=c.erp收款单单据号 where cPZNum is not null ";
                    DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int count = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] dw = dts.Select("收款单ID='" + dt.Rows[i]["收款单ID"].ToString().Trim() + "'");
                        if (dw.Length > 0)
                        {
                            ocmd.CommandText = @"insert into CW_RECE_BILL_LISTS(YRB_CHB_BILLID,YRB_RCV_RCVID,YRB_REL_ID,YRB_VOUCHER,
                        YRB_VOUCHER_TM,YRB_VOUCHER_EMPTID,YRB_TYPE) 
                        values('" + dt.Rows[i]["发票ID"].ToString() + "','" + dt.Rows[i]["核销单ID"].ToString() + "','" + dt.Rows[i]["收款单ID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "'," +
                            "TO_DATE('" + DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "',null)";
                            ocmd.ExecuteNonQuery();
                            count = count + 1;
                        }
                    }
                    otrans.Commit();
                    if (count > 0)
                    {
                        MessageBox.Show("凭证反写成功,共" + count + "条");
                    }
                    else
                    {
                        MessageBox.Show("无需要反写的凭证");
                    }
                }
                catch (Exception error)
                {
                    otrans.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void rdo未导入_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdo未导入.Checked == true)
                {
                    btnSave.Enabled = true;
                    simpleButton1.Enabled = false;
                    gridControl1.DataSource = null;
                }
                else
                {
                    btnSave.Enabled = false;
                    simpleButton1.Enabled = true;
                    gridControl1.DataSource = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSQL = "";
                int scount = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                    {

                        string 发票ID = gridView1.GetRowCellValue(i, gridCol发票ID).ToString().Trim();
                        string 发票号码 = gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim();
                        string 收款单ID = gridView1.GetRowCellValue(i, gridCol收款单ID).ToString().Trim();
                        sSQL = "delete from ERP_IMPORT_AP where 发票ID='" + 发票ID + "' and 发票号码='" + 发票号码 + "' and 收款单ID='" + 收款单ID + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        scount = scount + 1;
                    }

                }

                tran.Commit();

                MessageBox.Show("取消导入成功,共" + scount + "条");

                gridControl1.DataSource = null;

            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }
        }
    }
}





