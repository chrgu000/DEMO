using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UFIDA.U8.UAP.UI.Runtime.Model;
using System.Threading;
using UFIDA.U8.UAP.Common;
using System.Data;
using System.Windows.Forms;
using TH.BaseClass;

namespace UAP_ClientPlugin_AR
{

    /// <summary>
    /// UAP样例按钮
    /// </summary>
    public class BtnAR_CreateAccountingDocument : IButtonEventHandler
    {

        LoginInfo _LoginInfo = null;

        DataTable dtLanguage = null;
        public BtnAR_CreateAccountingDocument(LoginInfo LoginInfo)
        {
            _LoginInfo = LoginInfo;

            sLangType = _LoginInfo.LanguageRegion.ToLower();


            try
            {
                string sErr = "";
                SqlConnection conn = new SqlConnection(_LoginInfo.UFDataSqlConStr);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = @"
select * from   _UAP_Language where cVoucher = 'UAP_ClientPlugin_AR'
";
                    dtLanguage = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtLanguage == null || dtLanguage.Rows.Count == 0)
                    {
                        if (sLangType == "" || sLangType == "zh-cn")
                            sErr = "请设置语言";
                        if (sLangType == "en-us")
                            sErr = "Please set language";

                        if (sErr != "")
                        {
                            throw new Exception(sErr);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ee)
            { }
        }

        string sLangType = "";
        /// <summary>
        /// 获得语言
        /// </summary>
        /// <param name="s">中文</param>
        /// <param name="sLangType">语言种类</param>
        /// <returns>按照语种返回对应语种的数据</returns>
        public string sGetLanguage(string s)
        {
            string sReturn = "";

            if (dtLanguage == null || dtLanguage.Rows.Count == 0)
            {
                sReturn = s;
            }
            else
            {
                DataRow[] dr = dtLanguage.Select(" [zh-cn] = '" + s.Trim() + "'");
                if (dr.Length == 0)
                {
                    sReturn = s;
                }
                else
                {
                    sReturn = dr[0][sLangType].ToString().Trim();
                }
            }

            return sReturn;
        }
        /// <summary>
        /// 按钮事情真正执行
        /// </summary>
        /// <param name="ReceiptObject"></param>
        /// <param name="PreExcuteResult"></param>
        /// <returns></returns>
        public string Excute(VoucherProxy ReceiptObject, string PreExcuteResult)
        {
            //Business business = ReceiptObject.Businesses["表体实体ID"]; //取表体实体
            //string str = business.Rows[0].Cells["列名称"].Value; //取表体第一行  某列的值


            ////增加少量数据可以通过修改实体的方式，但是这种方式会有性能问题，每次修改单元格 都会导致界面刷新。
            //Business subEntity = ReceiptObject.Businesses["U8CUSTDEF_0004_E002"];//子表实体 U8CUSTDEF_0004_E002是子表实体编号，可以在UAP中看到
            //for (int i = 0; i < 10; i++)
            //{
            //    string rowKey = subEntity.AddRow(); //rowKey是行 主键值
            //    subEntity.Rows[rowKey].Cells["fQuantity"].Value = "1";
            //    subEntity.Rows[rowKey].Cells["fPrice"].Value = "1";
            //    subEntity.Rows[rowKey].Cells["fAmount"].Value = "1";
            //    subEntity.Rows[rowKey].Cells["cDetailMemo"].Value = "备注" + i.ToString();
            //}

            string sErr = "";
            try
            {
                SqlConnection conn = new SqlConnection(_LoginInfo.UFDataSqlConStr);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    #region 读取数据
                    DataSet ds = ReceiptObject.GetData(false, false);
                    DataTable dtHad = ds.Tables[0];

                    DataTable dtDs = ds.Tables[1];

                    DateTime dtmLogin = BaseFunction.ReturnDate(dtHad.Rows[0]["dDate"]);
                    int year = dtmLogin.Year;
                    int month = dtmLogin.Month;

                    string sVouCode = dtHad.Rows[0]["cCode"].ToString().Trim();
                    if (sVouCode == "")
                    {
                        string msg = sGetLanguage("获取单据号失败");
                        throw new Exception(msg);
                    }
                    
                    //应收是否结账
                    string sSQL = "select isnull(bflag_AR,0) as bflag_AR from GL_mend where iyear = {0} and iperiod = {1}";
                    sSQL = string.Format(sSQL, year, month);
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0 && BaseFunction.ReturnBool(dtTemp.Rows[0]["bflag_AR"]))
                    {
                        string msg = sGetLanguage("已经结账");
                        throw new Exception(msg);
                    }

                    #region 检查汇兑损益基础档案

                    sSQL = @"
select * from TH_ArAp_Set
";
                    DataTable dtSet = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtSet == null || dtSet.Rows.Count ==0)
                    {
                        string msg = sGetLanguage("请设置基础档案");
                        throw new Exception(msg);
                    }

                 
                    //摘要 - 汇兑损益已实现
                    string sDigest = dtSet.Rows[0]["cDigest"].ToString().Trim();
                    if (sDigest == "")
                    {
                        string msg = sGetLanguage("请设置摘要");
                        throw new Exception(msg);
                    }
                    //凭证类别 - 汇兑损益已实现
                    string sSign = dtSet.Rows[0]["cSign"].ToString().Trim();
                    if (sSign == "")
                    {
                        string msg = sGetLanguage("请设置凭证类别");
                        throw new Exception(msg);
                    }

                    //会计科目 - 汇兑损益已实现
                    string sDeptor = dtSet.Rows[0]["Deptor"].ToString().Trim();
                    string sCredit = dtSet.Rows[0]["Credit"].ToString().Trim();
                    if (sDeptor == "" || sCredit == "")
                    {
                        string msg = sGetLanguage("请设置会计科目");
                        throw new Exception(msg);
                    }

                    
                    #endregion


                    DateTime dtmStart = BaseFunction.ReturnDate(year + "-" + month + "-01");
                    DateTime dtmEnd = dtmStart.AddMonths(1);

                    sSQL = @"
select  cexch_code,cexch_name from dbo.foreigncurrency  where iotherused = -1
";
                    DataTable dtLocal = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtLocal.Rows.Count == 0)
                    {
                        string msg = sGetLanguage("未设置本币币种");
                        throw new Exception(msg);
                    }
                    string localExName = dtLocal.Rows[0]["cexch_name"].ToString();

                    #endregion

                    //判断是否审核
                    sSQL = @"
select distinct ISNULL(cAuditor,'') as cAuditor from TH_AR_HDSY 
where 1=1 and year(dDate) = {0} and month(dDate) = {1}
";
                    sSQL = string.Format(sSQL, year, month);
                    dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp == null || dtTemp.Rows.Count == 0 || dtTemp.Rows[0][0].ToString().Trim() == "")
                    {
                        string msg = sGetLanguage("单据尚未审核");
                        throw new Exception(msg);
                    }

                    //判断凭证是否已经生成

                    sSQL = @"
select distinct isnull(PZH, '') as PZH
from TH_AR_HDSY a inner join TH_AR_HDSYs b on a.TH_AR_HDSY_PK = b.TH_AR_HDSY_PK
where 1=1 and a.cCode = '{0}'
";
                    sSQL = string.Format(sSQL,sVouCode);
                    DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtExists != null && dtExists.Rows.Count > 0)
                    {
                        long i_id = BaseFunction.ReturnLong(dtExists.Rows[0]["PZH"]);
                        
                        sSQL = @"
select *
from GL_accvouch 
where 1=1 and isnull(iflag,0) = 0 
    and  iyear = {0} and iperiod = {1}
    and (i_id = {2})
                    ";

                        sSQL = string.Format(sSQL, year, month, i_id);
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string msg = sGetLanguage("已经生成凭证");
                            throw new Exception(msg);
                        }
                    }
                    sSQL = @"
select a.cCode,a.cAuditor,b.dRate,b.exchname
	,SUM(b.iAmount_f1) as iExchSum
	,SUM(b.HDSY) AS HDSY
from TH_AR_HDSY a inner join TH_AR_HDSYs b on a.TH_AR_HDSY_PK = b.TH_AR_HDSY_PK
where a.cCode = '{0}'
group by a.cCode,a.cAuditor,b.dRate,b.exchname
order by b.exchname

";
                    sSQL = string.Format(sSQL, sVouCode);
                    DataTable dtDetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    ////大数据刷新显示
                    //ReceiptObject.Refresh(ds);

                    int iCount = 0;
                    int iRow = 0;
                    string sVouchCode = "";

                    #region 生成凭证 - 汇兑损益已实现
                    //获得凭证号
                    sSQL = "select isnull(max(ino_id),0)  from GL_accvouch where iyear = {0} AND iperiod = {1} and csign = '{2}'";
                    sSQL = string.Format(sSQL, year, month, sSign);
                    DataTable dtinoid = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int ino_id1 = BaseFunction.ReturnInt(dtinoid.Rows[0][0]) + 1;

                    for (int i = 0; i < dtDetails.Rows.Count; i++)
                    {
                        decimal dHDSY = BaseFunction.ReturnDecimal(dtDetails.Rows[i]["HDSY"]);
                        if (dHDSY != 0)
                        {
                            sSQL = @"
select isignseq from dsign where csign = '{0}'
";
                            sSQL = string.Format(sSQL, sSign);
                            dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            iRow += 1;
                            #region 借方
                            Model.GL_accvouch model = new Model.GL_accvouch();
                            model.iperiod = BaseFunction.ReturnInt(month);
                            model.csign = sSign;
                            model.isignseq = BaseFunction.ReturnInt(dtTemp.Rows[0]["isignseq"]);
                            model.ino_id = ino_id1;
                            model.inid = iRow;
                            model.dbill_date = _LoginInfo.LoginDate;
                            model.idoc = 0;
                            model.cbill = _LoginInfo.UserName;
                            model.ibook = 0;
                            model.cdigest = sDigest;
                            model.ccode = sDeptor;
                            //model.cDefine1 = sDocment2;
                            model.md = BaseFunction.ReturnDecimal(dHDSY, 2);
                            model.mc = 0;
                            model.md_f = 0;
                            model.mc_f = 0;
                            model.nfrat = 0;
                            model.nd_s = 0;
                            model.nc_s = 0;
                            //model.csettle = "";     //结算方式
                            //model.cn_id
                            //model.dt_date = 

                            model.ccode_equal = sCredit;
                            model.bdelete = false;
                            //model.doutbilldate = model.dbill_date;
                            model.bvouchedit = true;
                            model.bvouchAddordele = false;
                            model.bvouchmoneyhold = false;
                            model.bvalueedit = true;
                            model.bcodeedit = true;
                            model.bPCSedit = true;
                            model.bDeptedit = true;
                            model.bItemedit = true;
                            model.bCusSupInput = false;
                            model.bFlagOut = false;
                            model.RowGuid = Guid.NewGuid().ToString();
                            model.iyear = BaseFunction.ReturnInt(year);
                            model.iYPeriod = BaseFunction.ReturnInt(BaseFunction.ReturnDate(year.ToString() + "-" + month.ToString() + "-01").ToString("yyyyMM"));
                            model.tvouchtime = DateTime.Now;
                            model.ccodeexch_equal = sCredit;

                            DAL.GL_accvouch dalGL = new DAL.GL_accvouch();
                            sSQL = dalGL.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            #endregion
                            
                            #region 贷方
                            iRow += 1;
                            model = new Model.GL_accvouch();
                            model.iperiod = BaseFunction.ReturnInt(month);
                            model.csign = sSign;
                            model.isignseq = BaseFunction.ReturnInt(dtTemp.Rows[0]["isignseq"]);
                            model.ino_id = ino_id1;
                            model.inid = iRow;
                            model.dbill_date = _LoginInfo.LoginDate;
                            model.idoc = 0;
                            model.cbill = _LoginInfo.UserName;
                            model.ibook = 0;
                            model.cdigest = sDigest;
                            model.ccode = sCredit;
                            //model.cDefine1 = sDocment2;
                            model.mc = 0;
                            model.md = -1 * BaseFunction.ReturnDecimal(dHDSY, 2);
                            model.md_f = 0;
                            model.mc_f = 0;
                            model.nfrat = 0;
                            model.nd_s = 0;
                            model.nc_s = 0;
                            //model.csettle = "";     //结算方式
                            //model.cn_id
                            //model.dt_date = 

                            model.ccode_equal = sDeptor;
                            model.bdelete = false;
                            model.doutbilldate = model.dbill_date;
                            model.bvouchedit = true;
                            model.bvouchAddordele = false;
                            model.bvouchmoneyhold = false;
                            model.bvalueedit = true;
                            model.bcodeedit = true;
                            model.bPCSedit = true;
                            model.bDeptedit = true;
                            model.bItemedit = true;
                            model.bCusSupInput = false;
                            model.bFlagOut = false;
                            model.RowGuid = Guid.NewGuid().ToString();
                            model.iyear = BaseFunction.ReturnInt(year);
                            model.iYPeriod = BaseFunction.ReturnInt(BaseFunction.ReturnDate(year.ToString() + "-" + month.ToString() + "-01").ToString("yyyyMM"));
                            model.tvouchtime = DateTime.Now;
                            model.ccodeexch_equal = sDeptor;

                            dalGL = new DAL.GL_accvouch();
                            sSQL = dalGL.Add(model);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            #endregion
                        }
                    }
                    if (iCount > 0)
                    {
                        sSQL = @"
select i_id
from GL_accvouch 
where iyear = {0} AND iperiod = {1} and csign = '{2}' and ino_id = {3}
";
                        sSQL = string.Format(sSQL, year, month, sSign, ino_id1);
                        DataTable dt_Exists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        
                        sSQL = @"
update TH_AR_HDSYs set PZH = '{0}'
where TH_AR_HDSY_PK in (select TH_AR_HDSY_PK from TH_AR_HDSY where year(dDate) = {1} and month(dDate) = {2}) 
";
                        sSQL = string.Format(sSQL, dt_Exists.Rows[0]["i_id"], year, month);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        sVouchCode = sVouchCode + sSign + "-" + ino_id1.ToString().PadLeft(4, '0');
                    }

                    #endregion
                    
                    //大数据刷新显示
                    //ReceiptObject.Refresh(ds);

                    tran.Commit();

                    string sMsg = sGetLanguage("生成凭证成功");
                    sMsg = sMsg + ":\n" + sVouchCode;
                    MessageBox.Show(sMsg);

                    return null;
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                return "<result><system result=\"false\" errinfo=\"" + ee.Message + "\"/></result>";   //返回false     不执行Excuted
            }
        }

        /// <summary>
        /// 按钮事件执行后
        /// </summary>
        /// <param name="ReceiptObject"></param>
        /// <param name="PreExcuteResult"></param>
        /// <returns></returns>
        public string Excuted(VoucherProxy ReceiptObject, string PreExcuteResult)
        {

            return string.Empty;



        }

        /// <summary>
        /// 按钮事件执行前
        /// </summary>
        /// <param name="ReceiptObject"></param>
        /// <returns></returns>
        public string Excuting(VoucherProxy ReceiptObject)
        {
            // return string.Empty;                                                                  //返回空字符换  继续执行Excute
            return "<result><system result=\"true\" errinfo=\"" + "" + "\"/></result>";              //返回true      继续执行Excute
            //return "<result><system result=\"false\" errinfo=\"" + "错误信息" + "\"/></result>";   //返回false     不执行Excute
        }

    }

}
