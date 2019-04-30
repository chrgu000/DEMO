using System;
using System.Data;
using System.Text;
using TH.WebService.BaseClass;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Drawing;


namespace TH.WebService.DAL
{
    /// <summary>
    /// 数据访问类:_BarCodeRD
    /// </summary>
    public partial class _BarCodeRD
    {
        public _BarCodeRD()
        { }

        /// <summary>
        /// 标签数量调整后打印标签
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string PrintBarCodeAdjust(string sBarCode,string sPrintName)
        {
            string sReturn = "";
            try
            {
                _BarCodeList barcodelist = new _BarCodeList();
                DataTable dtBarCode = barcodelist.dtScanBarCode(sBarCode);
                if (dtBarCode == null || dtBarCode.Rows.Count < 1)
                {
                    throw new Exception("获得条形码信息失败");
                }

                PrintDocument printDocument = new PrintDocument();

                printDocument.PrinterSettings.PrinterName = sPrintName;

                foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName == "CustomerDEMO")
                    {
                        printDocument.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        printDocument.DefaultPageSettings.PaperSize = ps;
                    }
                }

                TH.WebService.DAL.BarCodePrint barPrint = new BarCodePrint(dtBarCode);
                printDocument.PrintPage += new PrintPageEventHandler(barPrint.TextPrint_PrintPage);
                // 开始打印 
                if (printDocument.PrinterSettings.IsValid)
                {
                    printDocument.Print();
                }

                sReturn = "成功";
            }
            catch (Exception ee)
            {
                sReturn = "Err : " + ee.Message;
            }

            return sReturn;
        }

         /// <summary>
        /// 打印标签条码
        /// </summary>
        /// <param name="sBarCode"></param>
        /// <returns></returns>
        public string PrintBarCodeQTY(string sBarCode,decimal dQty, string sPrintName)
        {
            string sReturn = "";
            try
            {
                _BarCodeList barcodelist = new _BarCodeList();
                DataTable dtBarCode = barcodelist.dtScanBarCode(sBarCode);
                if (dtBarCode == null || dtBarCode.Rows.Count < 1)
                {
                    throw new Exception("获得条形码信息失败");
                }

                dtBarCode.Rows[0]["可用量"] = dQty.ToString();

                //打印机设定
                PrintDocument printDocument = new PrintDocument();

                printDocument.PrinterSettings.PrinterName = sPrintName;

                foreach (PaperSize ps in printDocument.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName == "CustomerDEMO")
                    {
                        printDocument.PrinterSettings.DefaultPageSettings.PaperSize = ps;
                        printDocument.DefaultPageSettings.PaperSize = ps;
                    }
                }

                TH.WebService.DAL.BarCodePrint barPrint = new BarCodePrint(dtBarCode);
                printDocument.PrintPage += new PrintPageEventHandler(barPrint.TextPrint_PrintPage);
                // 开始打印 
                if (printDocument.PrinterSettings.IsValid)
                {
                    printDocument.Print();
                }

                sReturn = "成功";
            }
            catch (Exception ee)
            {
                sReturn = "Err : " + ee.Message;
            }

            return sReturn;
        }


        /// <summary>
        /// 标签数量调整
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public int iSaveBarCodeAdjust(string sBarCode, decimal dQty, decimal dQtyUse, string CreateUid)
        {
            int iCou = 0;
            try
            {
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DataTable dtTime = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    DateTime dtmNow = BaseFunction.ReturnDate(dtTime.Rows[0][0]);
                    string s_BarCodeRDCode = BaseFunction.ReturnDate(dtTime.Rows[0][0]).ToString("yyMMddHHmmss");

                    sSQL = "select * from _BarCodeList where BarCode = '" + sBarCode + "'";
                    DataTable dtBarCode = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    TH.WebService.Model._BarCodeRD model = new TH.WebService.Model._BarCodeRD();
                    model.sCode = s_BarCodeRDCode;
                    model.BarCode = sBarCode;
                    model.sType = "条码数量调整";
                    if (dQty < 0)
                    {
                        model.RDType = 1;
                        model.Qty = -1 * dQty;
                    }
                    else
                    {
                        model.RDType = 2;
                        model.Qty = dQty;
                    }
                    model.CreateUid = CreateUid;
                    model.CreateDate = dtmNow;
                    model.cInvCode = dtBarCode.Rows[0]["cInvCode"].ToString().Trim();

                    sSQL = Add(model);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (dQty == dQtyUse)
                    {
                        sSQL = "update dbo._BarCodeList set valid = 0,Used = 1 where BarCode = '" + sBarCode + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    else
                    {
                        sSQL = "update dbo._BarCodeList set valid = 1,Used = 1 where BarCode = '" + sBarCode + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();

                    #region 发送邮件
                    _BarCodeList bar = new _BarCodeList();
                    decimal dQtyNow = bar.dBarCodeQty(model.BarCode);
                    sSQL = "select * from _MailAddress where sType = '标签数量调整'";
                    DataTable dtMailAddress = DbHelperSQL.Query(sSQL);
                    if (dtMailAddress != null && dtMailAddress.Rows.Count > 0)
                    {
                        string sMailAddress = dtMailAddress.Rows[0]["MailAddress"].ToString().Trim();
                        string sMail = "条形码 " + model.BarCode + " 物料 [" + model.cInvCode + "]" + dtBarCode.Rows[0]["cInvName"] + " 的数量调整为 " + dQtyNow.ToString();

                        sSQL = @"Exec msdb.dbo.sp_send_dbmail @profile_name='MailSet',
                        @recipients='111111',
                        @subject='222222',
                        @body='" + sMail + "'";

                        sSQL = sSQL.Replace("111111", sMailAddress);
                        sSQL = sSQL.Replace("222222", dtMailAddress.Rows[0]["Subject"].ToString().Trim());
                        DbHelperSQL.ExecuteSql(sSQL);

                    }
                    #endregion

                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return iCou;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.WebService.Model._BarCodeRD model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sCode != null)
            {
                strSql1.Append("sCode,");
                strSql2.Append("'" + model.sCode + "',");
            }
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.BarCode != null)
            {
                strSql1.Append("XBarCode,");
                strSql2.Append("'" + model.XBarCode + "',");
            }
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.ExsID != null)
            {
                strSql1.Append("ExsID,");
                strSql2.Append("" + model.ExsID + ",");
            }
            if (model.ExCode != null)
            {
                strSql1.Append("ExCode,");
                strSql2.Append("'" + model.ExCode + "',");
            }
            if (model.ExRowNo != null)
            {
                strSql1.Append("ExRowNo,");
                strSql2.Append("" + model.ExRowNo + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }

            if (model.RDType != null)
            {
                strSql1.Append("RDType,");
                strSql2.Append("" + model.RDType + ",");
            }
            strSql.Append("insert into _BarCodeRD(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.WebService.Model._BarCodeRD DataRowToModel(DataRow row)
        {
            TH.WebService.Model._BarCodeRD model = new TH.WebService.Model._BarCodeRD();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["sCode"] != null)
                {
                    model.sCode = row["sCode"].ToString();
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["XBarCode"] != null)
                {
                    model.XBarCode = row["XBarCode"].ToString();
                }
                if (row["sType"] != null)
                {
                    model.sType = row["sType"].ToString();
                }
                if (row["ExsID"] != null && row["ExsID"].ToString() != "")
                {
                    model.ExsID = int.Parse(row["ExsID"].ToString());
                }
                if (row["ExCode"] != null)
                {
                    model.ExCode = row["ExCode"].ToString();
                }
                if (row["ExRowNo"] != null && row["ExRowNo"].ToString() != "")
                {
                    model.ExRowNo = int.Parse(row["ExRowNo"].ToString());
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["Qty"] != null && row["Qty"].ToString() != "")
                {
                    model.Qty = decimal.Parse(row["Qty"].ToString());
                }
                if (row["CreateUid"] != null)
                {
                    model.CreateUid = row["CreateUid"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["RDType"] != null && row["RDType"].ToString() != "")
                {
                    model.RDType = int.Parse(row["RDType"].ToString());
                }
            }
            return model;
        }
    }
}

