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
    public partial class 销售发票导入 : UserControl
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

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public 销售发票导入()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit结束日期.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit开始日期.EditValue = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-01";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "加载数据失败");
                //throw new Exception(ee.Message);
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

                DataTable dtGrid = (DataTable)gridControl1.DataSource;
                dtGrid = Select(dtGrid, "选择='True'","");
                string sErr = "";
                string sSQL = "";

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
                            sSQL = "select count(1) from ERP_IMPORT_SALE where 发票号码 = '" + dtGrid.Rows[i]["发票号码"].ToString().Trim() + "' ";
                            int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou1 > 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据号已导入\n";
                                continue;
                            }

                            sSQL = "select count(1) from Ap_Vouch where cDefine1 = '" + dtGrid.Rows[i]["发票号码"].ToString().Trim() + "' ";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou > 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "发票号已存在\n";
                                continue;
                            }
                        }
                    }

                    sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                    DataTable dt结账状态 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string iperiod = "";
                    string iyear = "";
                    string iyperiod="";
                    if (dt结账状态.Rows.Count > 0)
                    {
                        iperiod = dt结账状态.Rows[0]["iperiod"].ToString().Trim();
                        iyear = dt结账状态.Rows[0]["iyear"].ToString().Trim();
                        iyperiod = dt结账状态.Rows[0]["iyperiod"].ToString().Trim();
                    }

                    int i凭证号 = 0;
                    sSQL = "select isnull(max(ino_id),0) as ino_id from gl_accvouch where iperiod =" + iperiod + " and isignseq =1  and iyear=" + iyear + "";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        i凭证号 = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                    }

                    sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity where cVouchType = 'RP' and cAcc_Id = '" + sAccID + "'";
                    DataTable dtID = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lID = 0;
                    long lIDMain = 0;
                    long lIDDetails = 0;
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lID = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iFatherId"]);
                        lIDDetails = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iChildId"]);
                    }

                    sSQL = "SELECT isnull(iCancelNo,0) as iCancelNo FROM Ap_CancelNo where cType='PZ' and cFlag='GL'";
                    DataTable dtgl = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long glid = SqlHelper.ReturnObjectToLong(dtgl.Rows[0]["iCancelNo"]);

                    sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='R0' and cContent is NULL";
                    DataTable dtcode = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long code = 0;
                    if (dtcode.Rows.Count > 0)
                    {
                        code = SqlHelper.ReturnObjectToLong(dtcode.Rows[0][0]);
                    }

                    int scount = 0;
                    int ocount = 0;
                    //应收款
                    DataTable dtgroup = Group(dtGrid, new string[] { "发票号码", "选择", "付费代理", "付费方式", "币种", "汇率", "发票总金额", "借方科目", "发票ID", "贷方科目税", "发票打印时间" }, "付费方式<>'XJ'");
                    for (int j = 0; j < dtgroup.Rows.Count; j++)
                    {
                        #region 数据验证

                        string s客户 = dtgroup.Rows[j]["付费代理"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s客户 + "' or cCusName = '" + s客户 + "' or cCusAbbName = '" + s客户 + "'";
                        DataTable dt客户 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt客户 == null || dt客户.Rows.Count < 1)
                        {
                            sErr = sErr + "客户" + s客户 + "不存在\n";
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
                            sErr = sErr + "币种不存在\n";
                            continue;
                        }



                        #endregion

                        #region
                        lID += 1;
                        lIDMain = ReturnID(lID);

                        code += 1;
                        string icode = sGetCode(code, 10);


                        decimal 发票金额 = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["发票总金额"]);
                        decimal 汇率 = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["汇率"]);
                        decimal 外币发票金额 = 发票金额 * 汇率;
                        string 币种 = dt币种.Rows[0]["cexch_name"].ToString().Trim();
                        string 客户 = dt客户.Rows[0]["cCusCode"].ToString().Trim();
                        string 借方科目 = dtgroup.Rows[j]["借方科目"].ToString().Trim();
                        string 发票号码 = dtgroup.Rows[j]["发票号码"].ToString().Trim();
                        string 贷方科目税 = dtgroup.Rows[j]["贷方科目税"].ToString().Trim();
                        string bd_c = "1";
                        if (发票金额 < 0)
                        {
                            bd_c = "0";
                        }

                        sSQL = @"Insert Into Ap_Vouch (cLink,cVouchType,cVouchID,dVouchDate,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cCode,
cexch_name,iExchRate,bd_c,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator,bStartFlag,cFlag,
cDefine1,iAmount_s,iRAmount_s,VT_ID,cItemName,iCreditPeriod,dGatheringDate,dcreatesystime,Auto_ID,cDefine10) Values (
N'R0" + icode + "',N'R0',N'" + icode + "','" + DateTime.Parse(dtgroup.Rows[j]["发票打印时间"].ToString()).ToString("yyyy-MM-dd") + "',N'" + 客户 + "',null,null,null,null,N'" + 借方科目 + "'," +
"N'" + 币种 + "','" + 汇率 + "'," + bd_c + "," + System.Math.Abs(发票金额) + "," + System.Math.Abs(外币发票金额) + "," + System.Math.Abs(发票金额) + "," + System.Math.Abs(外币发票金额) + ",N'" + sUserName + "',0,N'AR'," +
"N'" + 发票号码 + "',0,0,8054,null,null,'" + DateTime.Parse(dtgroup.Rows[j]["发票打印时间"].ToString()).AddDays(15).ToString("yyyy-MM-dd") + "',GETDATE()," + lIDMain + ",'Y')";

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        scount = scount + 1;
                        DataTable dt汇总 = Group(dtGrid, new string[] { "财务统计类别代码" }, "付费方式<>'XJ' and 发票号码='" + 发票号码 + "'");
                        for (int i = 0; i < dt汇总.Rows.Count; i++)
                        {
                            #region
                            //sSQL = "select * from salebillvouch where csbvcode = '" + dtGrid.Rows[i]["发票号"].ToString().Trim() + "'";
                            //DataTable dt销售发票 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            //if (dt销售发票.Rows.Count == 0)
                            //{


                            lIDDetails += 1;
                            string 贷方科目 = dt汇总.Rows[i]["财务统计类别代码"].ToString().Trim();

                            string 金穗费目 = "";

                            DataTable dt金穗费目 = Select(dtGrid, "付费方式<>'XJ' and 发票号码='" + 发票号码 + "' and 财务统计类别代码='" + 贷方科目 + "'", "发票总金额 desc");
                            if (dt金穗费目.Rows.Count > 0)
                            {
                                金穗费目 = dt金穗费目.Rows[0]["金穗费目"].ToString();
                            }
                            decimal 金额 = 0;
                            decimal 税后 = 0;

                            DataRow[] dw金额 = dtGrid.Select("付费方式<>'XJ' and 发票号码='" + 发票号码 + "' and 财务统计类别代码='" + 贷方科目 + "'");
                            for (int s = 0; s < dw金额.Length; s++)
                            {
                                金额 = 金额 + SqlHelper.ReturnObjectToDecimal(dw金额[s]["金额"], 6);
                                税后 = 税后 + SqlHelper.ReturnObjectToDecimal(dw金额[s]["税后"], 6);
                            }
                            金额 = SqlHelper.ReturnObjectToDecimal(金额, 2);
                            税后 = SqlHelper.ReturnObjectToDecimal(税后, 2);

                            decimal 税 = 金额 - 税后;

                            decimal 外币税后 = 税后 * 汇率;
                            decimal 外币税 = 税 * 汇率;

                            sSQL = "select  count(*) from code where ccode='" + 贷方科目 + "' and bend=1";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "贷方科目不存在\n";
                                continue;
                            }

                            sSQL = @"INSERT INTO Ap_Vouchs(cLink,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cDigest,cCode,cexch_name,iExchRate,
bd_c,iAmount,iAmount_f,cItemName,iAmt_s,cDefine22,cDefine23,cDefine24,cDefine25,cDefine26,
cDefine27,cDefine28,cDefine29,cDefine30,cDefine31,cDefine32,cDefine33,cDefine34,cDefine35,cDefine36,cDefine37) VALUES (
N'R0" + icode + "',N'" + 客户 + "',NULL,NULL,NULL,NULL,'" + 金穗费目 + "',N'" + 贷方科目 + "',N'" + 币种 + "'," + 汇率 + "," +
"0," + 税后 + "," + 外币税后 + ",NULL,0,NULL,NULL,NULL,NULL,NULL," +
"NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            if (税 != 0)
                            {
                                lIDDetails += 1;

                                sSQL = @"INSERT INTO Ap_Vouchs(cLink,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cDigest,cCode,cexch_name,iExchRate,
bd_c,iAmount,iAmount_f,cItemName,iAmt_s,cDefine22,cDefine23,cDefine24,cDefine25,cDefine26,
cDefine27,cDefine28,cDefine29,cDefine30,cDefine31,cDefine32,cDefine33,cDefine34,cDefine35,cDefine36,cDefine37) VALUES (
N'R0" + icode + "',N'" + 客户 + "',NULL,NULL,NULL,NULL,'" + 金穗费目 + "',N'" + 贷方科目税 + "',N'" + 币种 + "'," + 汇率 + "," +
"0," + 税 + "," + 外币税 + ",NULL,0,NULL,NULL,NULL,NULL,NULL," +
"NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            #endregion
                        }

                        sSQL = @"insert into ERP_IMPORT_SALE(发票号码,发票ID,cVouchID) 
                                    values(" + ReturnDBString(发票号码) + "," + ReturnDBString(dtgroup.Rows[j]["发票ID"]) + ",'" + icode + "') ";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion
                    }
                    //现金
                    DataTable dtg日期 = Group(dtGrid, new string[] { "选择", "币种", "汇率", "借方科目", "贷方科目税", "发票打印时间" }, "付费方式='XJ'");
                    for (int j = 0; j < dtg日期.Rows.Count; j++)
                    {
                        #region 数据验证
                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtg日期.Rows[j]["币种"].ToString().Trim() + "' or cexch_name = '" + dtg日期.Rows[j]["币种"].ToString().Trim() + "'";
                        DataTable dt币种 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt币种.Rows.Count == 0)
                        {
                            sErr = sErr + "币种不存在\n";
                            continue;
                        }

                        DataTable dt发票金额 = Group(dtGrid, new string[] { "发票打印时间", "发票总金额", "发票号码" }, "发票打印时间='" + dtg日期.Rows[j]["发票打印时间"] + "' and 付费方式='XJ'");

                        decimal 发票金额 = 0;
                        string 发票号码 = "";
                        for (int i = 0; i < dt发票金额.Rows.Count; i++)
                        {
                            发票金额 = 发票金额 + SqlHelper.ReturnObjectToDecimal(dt发票金额.Rows[i]["发票总金额"]);
                            //if (发票号码 != "")
                            //{
                            //    发票号码 = 发票号码 + ",";
                            //}
                            //else
                            //{
                            //    发票号码 = 发票号码 + dt发票金额.Rows[i]["发票号码"].ToString().Trim();
                            //}
                        }
                        
                        decimal 汇率 = SqlHelper.ReturnObjectToDecimal(dtg日期.Rows[j]["汇率"]);
                        decimal 外币发票金额 = 发票金额 * 汇率;
                        string 币种 = dt币种.Rows[0]["cexch_name"].ToString().Trim();
                        //string 客户 = dt客户.Rows[0]["cCusCode"].ToString().Trim();
                        string 借方科目 = dtg日期.Rows[j]["借方科目"].ToString().Trim();
                        string 贷方科目税 = dtg日期.Rows[j]["贷方科目税"].ToString().Trim();
                        
                        string 发票打印时间 = dtg日期.Rows[j]["发票打印时间"].ToString().Trim();
                        int inid = 1;
                        i凭证号 = i凭证号 + 1;
                        glid = glid + 1;
                        string 对方科目 = "";
                        DataTable dtdf = Group(dtGrid, new string[] { "财务统计类别代码" }, "发票打印时间='" + dtg日期.Rows[j]["发票打印时间"] + "' and 付费方式='XJ'");
                        for (int i = 0; i < dtdf.Rows.Count; i++)
                        {
                            if (对方科目 != "")
                            {
                                对方科目 = 对方科目 + ",";
                            }
                            else
                            {
                                对方科目 = 对方科目 + dtdf.Rows[i]["财务统计类别代码"].ToString().Trim();
                            }
                        }

                        DataTable dt附录 = Group(dtGrid, new string[] { "发票号码" }, "发票打印时间='" + dtg日期.Rows[j]["发票打印时间"] + "' and 付费方式='XJ'");
                        int 附录 = dt附录.Rows.Count;
                        //借方
                        sSQL = @" declare @id as nvarchar
                            select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                        "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                          ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                          "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                          ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                          ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id ) " +
                               "values(" + iperiod + ",'收','1'," + i凭证号 + ",'1','" + 发票打印时间 + "'," + 附录 + ",'" + sUserName + "',null,null" +
                                        ",0,null,null,null,'现金收入','" + 借方科目 + "','" + 币种 + "'," + SqlHelper.ReturnObjectToDecimal(发票金额, 2) + ",0" +
                                        "," + SqlHelper.ReturnObjectToDecimal(外币发票金额, 2) + ",0," + 汇率 + ",0,0,null,null,null,null,null" +
                                        ",null,null,null,null,null,'" + 对方科目 + "',null,null,null,null" +
                                        ",'" + iyear + "','" + iperiod + "','" + 发票号码 + "','Y',@id)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        scount = scount + 1;

                        //科目备查资料表
                        sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','收'," + i凭证号 + ",'" + inid + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        decimal z税 = 0;
                        decimal z外币税 = 0;
                        string 税金摘要 = "";

                        DataTable dt税金摘要 = Select(dtGrid,"发票打印时间='" + dtg日期.Rows[j]["发票打印时间"] + "' and 付费方式='XJ'", "发票总金额 desc");
                        if (dt税金摘要.Rows.Count > 0)
                        {
                            税金摘要 = dt税金摘要.Rows[0]["金穗费目"].ToString()+"等";
                        }

                        #region
                        DataTable dtBack = Group(dtGrid, new string[] { "发票号码", "发票ID" }, "付费方式='XJ' and 发票打印时间='" + dtg日期.Rows[j]["发票打印时间"].ToString() + "'");
                        for (int s = 0; s < dtBack.Rows.Count; s++)
                        {
                            #region
                            //记录
                            sSQL = @"insert into ERP_IMPORT_SALE(发票号码,发票ID,iperiod ,ino_id,iyear ) 
                                    values(" + ReturnDBString(dtBack.Rows[s]["发票号码"]) + "," + ReturnDBString(dtBack.Rows[s]["发票ID"]) + ",'" + iperiod + "','" + i凭证号 + "','" + iyear + "') ";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            string 凭证 = ("0000" + i凭证号);
                            凭证 = "收-" + 凭证.Substring(凭证.Length - 4, 4);
                            ocmd.CommandText = @"insert into CW_SEND_CHB_LISTS(YSB_CHB_BILLID,YSB_VOUCHER,YSB_VOUCHER_TM,YSB_VOUCHER_EMPTID) values(
" + ReturnDBString(dtBack.Rows[s]["发票ID"]) + ",'" + 凭证 + "',TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + sUserName + "')";
                            ocmd.ExecuteNonQuery();
                            #endregion
                        }
                        //贷方
                        DataTable dtg贷方科目 = Group(dtGrid, new string[] { "选择", "币种", "汇率", "财务统计类别代码",  "发票打印时间" }, "付费方式='XJ' and 发票打印时间='" + dtg日期.Rows[j]["发票打印时间"].ToString() + "'");
                        for (int i = 0; i < dtg贷方科目.Rows.Count; i++)
                        {
                            #region
                            string 贷方科目 = dtg贷方科目.Rows[i]["财务统计类别代码"].ToString().Trim();
                            string 金穗费目 = "";
                            DataTable dt金穗费目 = Select(dtGrid, "付费方式='XJ' and 发票打印时间='" + dtg日期.Rows[j]["发票打印时间"].ToString() + "' and 财务统计类别代码='" + 贷方科目 + "'", "发票总金额 desc");
                            if (dt金穗费目.Rows.Count > 0)
                            {
                                金穗费目 = dt金穗费目.Rows[0]["金穗费目"].ToString();
                            }
                            decimal 税后 = 0;
                            decimal 税 = 0;
                            DataRow[] dw金额 = dtGrid.Select("付费方式='XJ' and 发票打印时间='" + 发票打印时间 + "' and 财务统计类别代码='" + 贷方科目 + "'");
                            for (int s = 0; s < dw金额.Length; s++)
                            {
                                税后 = 税后 + SqlHelper.ReturnObjectToDecimal(dw金额[s]["税后"], 2);
                                税 = 税 + SqlHelper.ReturnObjectToDecimal(dw金额[s]["税"], 2);
                            }

                            
                            decimal 外币税后 = 税后 * 汇率;
                            decimal 外币税 = 税 * 汇率;

                            z税 = 税 + z税;
                            z外币税 = 外币税 + z外币税;

                            sSQL = "select  count(*) from code where ccode='" + 贷方科目 + "' and bend=1";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "贷方科目不存在\n";
                                continue;
                            }
                            inid = inid + 1;
                            sSQL = @"declare @id as nvarchar
                            select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                    "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                      ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                      "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                      ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                      ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id) " +
                           "values(" + iperiod + ",'收','1'," + i凭证号 + ",'" + inid + "','" + 发票打印时间 + "'," + 附录 + ",'" + sUserName + "',null,null" +
                                    ",0,null,null,null,'" + 金穗费目 + "','" + 贷方科目 + "','" + 币种 + "',0," + SqlHelper.ReturnObjectToDecimal(税后, 2) + "," +
                                    "0," + SqlHelper.ReturnObjectToDecimal(外币税后, 2) + "," + 汇率 + ",0,0,null,null,null,null,null," +
                                    "null,null,null,null,null,'" + 借方科目 + "',null,null,null,null" +
                                    ",'" + iyear + "','" + iperiod + "','" + 发票号码 + "','Y',@id)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //科目备查资料表
                            sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','收'," + i凭证号 + ",'" + inid + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            

                            #endregion
                        }
                        #endregion
                        //税
                        if (z税 > 0)
                        {
                            inid = inid + 1;
                            sSQL = @"declare @id as nvarchar
                                                        select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                    "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                      ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                      "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                      ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                      ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id) " +
                           "values(" + iperiod + ",'收','1'," + i凭证号 + ",'" + inid + "','" + 发票打印时间 + "'," + 附录 + ",'" + sUserName + "',null,null" +
                                    ",0,null,null,null,'" + 税金摘要 + "','" + 贷方科目税 + "','" + 币种 + "',0," + SqlHelper.ReturnObjectToDecimal(z税, 2) + "," +
                                    "0," + SqlHelper.ReturnObjectToDecimal(z外币税, 2) + "," + 汇率 + ",0,0,null,null,null,null,null," +
                                    "null,null,null,null,null,'" + 借方科目 + "',null,null,null,null" +
                                    ",'" + iyear + "','" + iperiod + "','" + 发票号码 + "','Y',@id)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        //科目备查资料表
                        sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','收'," + i凭证号 + ",'" + inid + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        #endregion
                        #region

                        //现金流量
                        sSQL = @"insert into GL_CashTable (RowGuid,iYear,iPeriod,iSignSeq,csign,iNo_id,inid,cCashItem,md,mc,
ccode,md_f,mc_f,nd_s,nc_s,cdept_id,cperson_id,ccus_id,csup_id,citem_class,
citem_id,cDefine1,cDefine2,cDefine3,cDefine4,cDefine5,cDefine6,cDefine7,cDefine8,cDefine9,
cDefine10,cDefine11,cDefine12,cDefine13,cDefine14,cDefine15,dbill_date,cDefine16) values(
newid(),'" + iyear + "','" + iperiod + "',1,N'收'," + i凭证号 + ",1,N'01'," + 发票金额 + ",0," +
"N'" + 借方科目 + "',0,0,0,0,Null,Null,Null,Null,Null," +
"Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
"'Y',Null,Null,Null,Null,Null,N'" + DateTime.Now.ToString("yyyy-MM-dd") + "',Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        
                        
                        #endregion
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'RP' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update VoucherHistory set cNumber = " + code + " Where  CardNumber='R0' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update Ap_CancelNo set iCancelNo = " + glid + " Where  cType='PZ' and cFlag='GL'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    otrans.Commit();
                    tran.Commit();

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

                string sSQL = "select * from ERP_Link_TaxSub where 类别='SaleBillVouch'";
                DataTable dt科目 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                string s科目 = "";
                if (dt科目.Rows.Count > 0)
                {
                    s科目 = dt科目.Rows[0]["科目编码"].ToString();
                }
                if (s科目 == "")
                {
                    throw new Exception("贷方增值税科目未设置");
                }

                sSQL = @"select 开票地点,船名,航次,进出口,靠泊时间,付费方式,发票类型,a.发票号码,付费代理,付费人,币种,1 as 汇率,发票总金额,发票税额,TO_CHAR(发票打印时间,'YYYY-MM-DD') as 发票打印时间,开票人,
一级费目代码,一级费目,财务统计类别代码,财务统计类别,二级费目,金穗费目,发票内容,数量,单价,折扣,
税率,金额,金额-round(税后,6) 税,round(税后,6) as 税后,尺寸,空重,内外贸,箱类,进出,标准,船型,CHB_BILLID as 发票ID  from CW_SEND_BILL_VW a left join CW_SEND_CHB_LISTS b on a.CHB_BILLID=b.YSB_CHB_BILLID 
where  1=1 ";
                if (textBox发票ID.Text != "")
                {
                    sSQL = sSQL + " and CHB_BILLID='" + textBox发票ID.Text.Trim() + "'";
                }
                if (textBox发票号码.Text != "")
                {
                    sSQL = sSQL + " and a.发票号码='" + textBox发票号码.Text.Trim() + "'";
                }
                if (textBox客户.Text != "")
                {
                    sSQL = sSQL + " and 付费代理 like '%" + textBox客户.Text.Trim() + "%'";
                }

                if (dateEdit开始日期.Text != "")
                {
                    sSQL = sSQL + " and 发票打印时间>=to_date('"+dateEdit开始日期.DateTime.ToString("yyyy-MM-dd")+"','YYYY-MM-DD')";
                }
                if (dateEdit结束日期.Text != "")
                {
                    sSQL = sSQL + " and 发票打印时间<to_date('" + dateEdit结束日期.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }
                

                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                sSQL = "select * from ERP_IMPORT_SALE";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                for (int i = dt.Rows.Count -1 ; i >= 0; i--)
                {
                    if (rdo未导入.Checked == true)
                    {
                        if (dts.Select("发票ID='" + dt.Rows[i]["发票ID"].ToString() + "'").Length > 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    else
                    {
                        if (dts.Select("发票ID='" + dt.Rows[i]["发票ID"].ToString() + "'").Length == 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    
                }
                dt.Columns.Add("借方科目");
                dt.Columns.Add("贷方科目");
                dt.Columns.Add("贷方科目税");

                DataColumn dc = new DataColumn();
                dc.ColumnName = "选择";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                //dt.Columns.Add("选择",typeof(bool));
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["付费方式"].ToString().ToUpper().Trim() == "XJ")
                    {
                        dt.Rows[i]["借方科目"] = "1001";
                        dt.Rows[i]["贷方科目税"] = s科目;
                    }
                    else
                    {
                        dt.Rows[i]["借方科目"] = "1122";
                        dt.Rows[i]["贷方科目税"] = s科目;
                    }

                    string 贷方科目 = dt.Rows[i]["财务统计类别代码"].ToString().Trim();

                    sSQL = "select  count(*) from code where ccode='" + 贷方科目 + "' and bend=1";
                    int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                    if (iCou == 0)
                    {
                        sSQL = "select  count(*) from code where ccode=left('" + 贷方科目 + "',LEN('" + 贷方科目 + "')-2) and bend=1";
                        int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou1 > 0)
                        {
                            dt.Rows[i]["财务统计类别代码"] = 贷方科目.Substring(0, 贷方科目.Length - 2);
                        }
                    }

                    
                    
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
            GetChk(checkEdit1.Checked);
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
            CheckEdit edit = sender as CheckEdit;
            bool b = false;
            if (edit.Checked == true)
            {
                b = true;
            }
            decimal money = 0;
            int iRow = gridView1.FocusedRowHandle;
            string code = gridView1.GetRowCellValue(iRow, gridCol发票号码).ToString().Trim();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol发票号码).ToString().Trim() == code)
                {
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }
                if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                {
                    money = money + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol金额));
                }
            }
            txt总金额.Text = money.ToString();
        }

        public static DataTable Group(DataTable dt, string[] ColumnName,string Sel)
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
                string sSQL = @"select distinct 发票号码,a.CHB_BILLID as 发票ID from CW_SEND_BILL_VW a 
left join CW_SEND_CHB_LISTS c on a.CHB_BILLID=c.YSB_CHB_BILLID  where c.YSB_CHB_BILLID is  null";
                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                sSQL = @"select a.cVouchID,a.cPzID,cPZNum,b.cbill,b.dbill_date,c.发票id,a.Auto_ID,c.* from Ap_Vouch a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_SALE c on a.cVouchID=c.cVouchID
where cPZNum is not null AND c.cVouchID IS NOT NULL";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow[] dw = dts.Select("发票id='" + dt.Rows[i]["发票ID"].ToString().Trim() + "'");
                    if (dw.Length > 0)
                    {
                        ocmd.CommandText = @"insert into CW_SEND_CHB_LISTS(YSB_CHB_BILLID,YSB_VOUCHER,YSB_VOUCHER_TM,YSB_VOUCHER_EMPTID) values(
'" + dt.Rows[i]["发票ID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "',TO_DATE('" +DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "')";
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
                MessageBox.Show(error.Message);
            }
        }

        private void rdo未导入_CheckedChanged(object sender, EventArgs e)
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

        private void rdo已导入_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

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

                        sSQL = "delete from ERP_IMPORT_SALE where 发票ID='" + 发票ID + "' and 发票号码='" + 发票号码 + "'";
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