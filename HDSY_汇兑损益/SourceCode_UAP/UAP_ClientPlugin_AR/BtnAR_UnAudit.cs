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
    public class BtnAR_UnAudit : IButtonEventHandler
    {

        LoginInfo _LoginInfo = null;

        DataTable dtLanguage = null;
        public BtnAR_UnAudit(LoginInfo LoginInfo)
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
select * from   _UAP_Language where cVoucher = 'UAP_ClientPlugin_AR.BtnAR_ReadData'
";
                    dtLanguage = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtLanguage == null || dtLanguage.Rows.Count == 0)
                    {
                        if (sLangType == "" || sLangType == "zh-cn")
                            sErr = "请设置语言";
                        if (sLangType == "en-us")
                            sErr = "Please set language";

                        //if (sErr != "")
                        //{
                        //    throw new Exception(sErr);
                        //}
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
                    DataSet ds = ReceiptObject.GetData(false, false);
                    DataTable dtHad = ds.Tables[0];
                    
                    if (dtHad.Rows.Count == 0)
                    {
                        string msg = sGetLanguage("没有数据");
                        throw new Exception(msg);
                    }
                    string year = BaseFunction.ReturnDate(dtHad.Rows[0]["dDate"]).Year.ToString();
                    if (year == "")
                    {
                        string msg = sGetLanguage("请指定年");
                        throw new Exception(msg);
                    }

                    string month = BaseFunction.ReturnDate(dtHad.Rows[0]["dDate"]).Month.ToString();
                    if (month == "")
                    {
                        string msg = sGetLanguage("请指定月");
                        throw new Exception(msg);
                    }

                    string sVouCode = dtHad.Rows[0]["cCode"].ToString().Trim();
                    if (sVouCode == "")
                    {
                        string msg = sGetLanguage("获取单据号失败");
                        throw new Exception(msg);
                    }

                    //判断凭证是否已经生成
                    string sSQL = @"
select distinct isnull(PZH, '') as PZH
from TH_AR_HDSY a inner join TH_AR_HDSYs b on a.TH_AR_HDSY_PK = b.TH_AR_HDSY_PK
where 1=1 and a.cCode = '{0}'
";
                    sSQL = string.Format(sSQL, sVouCode);
                    DataTable dtExists = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtExists != null && dtExists.Rows.Count > 0)
                    {
                        long i_id = BaseFunction.ReturnLong(dtExists.Rows[0]["PZH"]);
                        
                        sSQL = @"
select *
from GL_accvouch 
where 1=1 and isnull(iflag,0) = 0 
    and iyear = {0} and iperiod = {1}
    and (i_id = {2} )
                    ";
                        sSQL = string.Format(sSQL, year, month, i_id);
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string msg = sGetLanguage("已经生成凭证，不能弃审");
                            throw new Exception(msg);
                        }
                    }
                    
                    tran.Commit();
                   
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
