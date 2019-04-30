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

namespace UAP_ClientPlugin_AP
{

    /// <summary>
    /// UAP样例按钮
    /// </summary>
    public class BtnAP_ReadData : IButtonEventHandler
    {

        LoginInfo _LoginInfo = null;

        DataTable dtLanguage = null;
        public BtnAP_ReadData(LoginInfo LoginInfo)
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
select * from   _UAP_Language where cVoucher = 'UAP_ClientPlugin_AP'
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

                    if (dtHad.Rows.Count == 0)
                    {
                        string msg = sGetLanguage("没有数据");
                        throw new Exception(msg);
                    }

                    dtHad.Rows[0]["dDate"] = _LoginInfo.LoginDate;

                    DateTime dtmLog = _LoginInfo.LoginDate;
                    int year = dtmLog.Year;
                    int month = dtmLog.Month;

                    #region 检查汇兑损益基础档案

                    string sSQL = @"
select * from TH_ArAp_Set
";
                    DataTable dtSet = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //摘要
                    if (dtSet.Rows[0]["cDigest"].ToString().Trim() == "")
                    {
                        string msg = sGetLanguage("请设置摘要");
                        throw new Exception(msg);
                    }
                    //凭证类别
                    if (dtSet.Rows[0]["cSign"].ToString().Trim() == "")
                    {
                        string msg = sGetLanguage("请设置凭证类别");
                        throw new Exception(msg);
                    }

                    //会计科目
                    if (dtSet.Rows[0]["Deptor"].ToString().Trim() == "" || dtSet.Rows[0]["Credit"].ToString().Trim() == "")
                    {
                        string msg = sGetLanguage("请设置会计科目");
                        throw new Exception(msg);
                    }

                    #endregion

                    sSQL = @"
select cCode from TH_AP_HDSY where year(dDate) = {0} and month(dDate) = {1}
";
                    sSQL = string.Format(sSQL, year, month);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string msg = sGetLanguage("当前期间已有数据");
                        throw new Exception(msg);
                    }

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

                    Business subEntity = ReceiptObject.Businesses["TH170901_0003_E002"];

                    subEntity.Clear();

                    sSQL = @"
exec [_TH_Get_AP] '{0}'
";
                    sSQL = string.Format(sSQL, dtmLog.ToString("yyyy-MM-dd"));
                    DataTable dtDetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    ////大数据刷新显示
                    ReceiptObject.Refresh(ds);

                    for (int i = 0; i < dtDetails.Rows.Count; i++)
                    {
                        // DataRow dr = dtSub.NewRow();
                        // dr["UAPAR001_0001_E001_PK"] = ReceiptObject.CurrentPKValue;  //必须给子表的外键 赋值，子表的外键值=主表的主键值
                        string rowKey = subEntity.AddRow(); //rowKey是行 主键值

                        subEntity.Rows[rowKey].Cells["ctypename1"].Value = sGetLanguage(dtDetails.Rows[i]["ctypename1"].ToString().Trim());     //单据类型
                        subEntity.Rows[rowKey].Cells["cvouchid1"].Value = dtDetails.Rows[i]["cvouchid1"].ToString().Trim();                     //业务单据号
                        subEntity.Rows[rowKey].Cells["dVouchDate1"].Value = dtDetails.Rows[i]["dVouchDate1"].ToString().Trim();                 //单据日期
                        subEntity.Rows[rowKey].Cells["cVenCode"].Value = dtDetails.Rows[i]["cDwCode"].ToString().Trim();                       //供应商编码
                        subEntity.Rows[rowKey].Cells["cVenName"].Value = dtDetails.Rows[i]["cDwName"].ToString().Trim();                       //供应商名称
                        subEntity.Rows[rowKey].Cells["exchname"].Value = dtDetails.Rows[i]["exchname"].ToString().Trim();                       //币种
                        subEntity.Rows[rowKey].Cells["iAmount_f1"].Value = dtDetails.Rows[i]["iAmount_f1"].ToString().Trim();                   //本期核销金额
                        subEntity.Rows[rowKey].Cells["HDSY"].Value = dtDetails.Rows[i]["HDSY"].ToString().Trim();                               //汇兑损益
                        subEntity.Rows[rowKey].Cells["dRate"].Value = dtDetails.Rows[i]["dRate"].ToString().Trim();                             //汇率
                    }

                    //大数据刷新显示
                    //ReceiptObject.Refresh(ds);

                    tran.Commit();

                    string sMsg = sGetLanguage("读取数据成功");
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
