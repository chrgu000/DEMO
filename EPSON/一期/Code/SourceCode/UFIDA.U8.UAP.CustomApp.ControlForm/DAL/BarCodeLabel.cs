using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_BarCodeLabel
    /// </summary>
    public partial class _BarCodeLabel
    {
        public _BarCodeLabel()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string BarCode, long iSOsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _BarCodeLabel");
            strSql.Append(" where BarCode='" + BarCode + "'  and isnull([Status],'') <> '关闭' ");
            return  (strSql.ToString());
        }

        public string sGetBarStatus(SqlTransaction tran, string sBarCode,long iSOsID)
        { 
            string sBarStatus = "";
            string sSQL = @"
select top 1 case when isnull(a.CloseUid,'') <> '' then '关闭' when isnull(c.iSOsID,0) = 0 then '单据删除'
	else a.[Status] end as BarStatus
from [dbo].[_BarCodeLabel] a left join [dbo].[_BarStatus] b on a.BarCode = b.BarCode
	left join SO_SODetails c on a.iSOsID = c.iSOsID
where a.BarCode = 'aaaaaa' and a.iSOsID = bbbbbb
order by b.iID desc
";
            sSQL = sSQL.Replace("aaaaaa", sBarCode);
            sSQL = sSQL.Replace("bbbbbb", iSOsID.ToString());
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dt == null || dt.Rows.Count == 0)
                sBarStatus = "不存在";
            else
            {
                sBarStatus = dt.Rows[0]["BarStatus"].ToString().Trim();
            }
            return sBarStatus;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.SaleOrderNo != null)
            {
                strSql1.Append("SaleOrderNo,");
                strSql2.Append("'" + model.SaleOrderNo + "',");
            }
            if (model.SaleOrderRowNo != null)
            {
                strSql1.Append("SaleOrderRowNo,");
                strSql2.Append("" + model.SaleOrderRowNo + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.cInvStd != null)
            {
                strSql1.Append("cInvStd,");
                strSql2.Append("'" + model.cInvStd + "',");
            }
            if (model.DEPT != null)
            {
                strSql1.Append("DEPT,");
                strSql2.Append("'" + model.DEPT + "',");
            }
            if (model.CUST != null)
            {
                strSql1.Append("CUST,");
                strSql2.Append("'" + model.CUST + "',");
            }
            if (model.ORDERNO != null)
            {
                strSql1.Append("ORDERNO,");
                strSql2.Append("'" + model.ORDERNO + "',");
            }
            if (model.CUSTDO != null)
            {
                strSql1.Append("CUSTDO,");
                strSql2.Append("'" + model.CUSTDO + "',");
            }
            if (model.CUSTLOT != null)
            {
                strSql1.Append("CUSTLOT,");
                strSql2.Append("'" + model.CUSTLOT + "',");
            }
            if (model.LOTNO != null)
            {
                strSql1.Append("LOTNO,");
                strSql2.Append("'" + model.LOTNO + "',");
            }
            if (model.LotSize != null)
            {
                strSql1.Append("LotSize,");
                strSql2.Append("" + model.LotSize + ",");
            }
            if (model.ORDERQTY != null)
            {
                strSql1.Append("ORDERQTY,");
                strSql2.Append("" + model.ORDERQTY + ",");
            }
            if (model.LOTQTY != null)
            {
                strSql1.Append("LOTQTY,");
                strSql2.Append("" + model.LOTQTY + ",");
            }
            if (model.RECDate != null)
            {
                strSql1.Append("RECDate,");
                strSql2.Append("'" + model.RECDate + "',");
            }
            if (model.DueDate != null)
            {
                strSql1.Append("DueDate,");
                strSql2.Append("'" + model.DueDate + "',");
            }
            if (model.Creater != null)
            {
                strSql1.Append("Creater,");
                strSql2.Append("'" + model.Creater + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.PrintTime != null)
            {
                strSql1.Append("PrintTime,");
                strSql2.Append("'" + model.PrintTime + "',");
            }
            if (model.PrintCount != null)
            {
                strSql1.Append("PrintCount,");
                strSql2.Append("" + model.PrintCount + ",");
            }
            if (model.oldBarCode != null)
            {
                strSql1.Append("oldBarCode,");
                strSql2.Append("'" + model.oldBarCode + "',");
            }
            if (model.CloseUid != null)
            {
                strSql1.Append("CloseUid,");
                strSql2.Append("'" + model.CloseUid + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.LOTQTY2 != null)
            {
                strSql1.Append("LOTQTY2,");
                strSql2.Append("" + model.LOTQTY2 + ",");
            }
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            if (model.Process != null)
            {
                strSql1.Append("Process,");
                strSql2.Append("'" + model.Process + "',");
            }
            if (model.RDType != null)
            {
                strSql1.Append("RDType,");
                strSql2.Append("'" + model.RDType + "',");
            }
            if (model.RDsID != null)
            {
                strSql1.Append("RDsID,");
                strSql2.Append("" + model.RDsID + ",");
            }
            if (model.BarKG != null)
            {
                strSql1.Append("BarKG,");
                strSql2.Append("'" + model.BarKG + "',");
            }
            if (model.Batch != null)
            {
                strSql1.Append("Batch,");
                strSql2.Append("'" + model.Batch + "',");
            }
            strSql.Append("insert into _BarCodeLabel(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel model, string sBarCode, long iSOsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _BarCodeLabel set ");

            if (model.PrintTime != null)
            {
                strSql.Append("PrintTime='" + model.PrintTime + "',");
            }
            else
            {
                strSql.Append("PrintTime= null ,");
            }
            if (model.PrintCount != null)
            {
                strSql.Append("PrintCount=" + model.PrintCount + ",");
            }
            else
            {
                strSql.Append("PrintCount= null ,");
            }

            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where BarCode='" + sBarCode + "' and iSOsID = " + iSOsID.ToString());
            return (strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel DataRowToModel(DataRow row)
        {

            UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["SaleOrderNo"] != null)
                {
                    model.SaleOrderNo = row["SaleOrderNo"].ToString();
                }
                if (row["SaleOrderRowNo"] != null && row["SaleOrderRowNo"].ToString() != "")
                {
                    model.SaleOrderRowNo = int.Parse(row["SaleOrderRowNo"].ToString());
                }
                if (row["iSOsID"] != null && row["iSOsID"].ToString() != "")
                {
                    model.iSOsID = int.Parse(row["iSOsID"].ToString());
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["cInvName"] != null)
                {
                    model.cInvName = row["cInvName"].ToString();
                }
                if (row["cInvStd"] != null)
                {
                    model.cInvStd = row["cInvStd"].ToString();
                }
                if (row["DEPT"] != null)
                {
                    model.DEPT = row["DEPT"].ToString();
                }
                if (row["CUST"] != null)
                {
                    model.CUST = row["CUST"].ToString();
                }
                if (row["ORDERNO"] != null)
                {
                    model.ORDERNO = row["ORDERNO"].ToString();
                }
                if (row["CUSTDO"] != null)
                {
                    model.CUSTDO = row["CUSTDO"].ToString();
                }
                if (row["CUSTLOT"] != null)
                {
                    model.CUSTLOT = row["CUSTLOT"].ToString();
                }
                if (row["LOTNO"] != null)
                {
                    model.LOTNO = row["LOTNO"].ToString();
                }
                if (row["LotSize"] != null && row["LotSize"].ToString() != "")
                {
                    model.LotSize = decimal.Parse(row["LotSize"].ToString());
                }
                if (row["ORDERQTY"] != null && row["ORDERQTY"].ToString() != "")
                {
                    model.ORDERQTY = decimal.Parse(row["ORDERQTY"].ToString());
                }
                if (row["LOTQTY"] != null && row["LOTQTY"].ToString() != "")
                {
                    model.LOTQTY = decimal.Parse(row["LOTQTY"].ToString());
                }
                if (row["RECDate"] != null && row["RECDate"].ToString() != "")
                {
                    model.RECDate = DateTime.Parse(row["RECDate"].ToString());
                }
                if (row["DueDate"] != null && row["DueDate"].ToString() != "")
                {
                    model.DueDate = DateTime.Parse(row["DueDate"].ToString());
                }
                if (row["Creater"] != null)
                {
                    model.Creater = row["Creater"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["PrintTime"] != null && row["PrintTime"].ToString() != "")
                {
                    model.PrintTime = DateTime.Parse(row["PrintTime"].ToString());
                }
                if (row["PrintCount"] != null && row["PrintCount"].ToString() != "")
                {
                    model.PrintCount = int.Parse(row["PrintCount"].ToString());
                }
                if (row["oldBarCode"] != null)
                {
                    model.oldBarCode = row["oldBarCode"].ToString();
                }
                if (row["CloseUid"] != null)
                {
                    model.CloseUid = row["CloseUid"].ToString();
                }
                if (row["CloseDate"] != null && row["CloseDate"].ToString() != "")
                {
                    model.CloseDate = DateTime.Parse(row["CloseDate"].ToString());
                }
                if (row["LOTQTY2"] != null && row["LOTQTY2"].ToString() != "")
                {
                    model.LOTQTY2 = decimal.Parse(row["LOTQTY2"].ToString());
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["Process"] != null)
                {
                    model.Process = row["Process"].ToString();
                }
                if (row["RDType"] != null)
                {
                    model.RDType = row["RDType"].ToString();
                }
                if (row["RDsID"] != null && row["RDsID"].ToString() != "")
                {
                    model.RDsID = int.Parse(row["RDsID"].ToString());
                }
                if (row["BarKG"] != null)
                {
                    model.BarKG = row["BarKG"].ToString();
                }
                if (row["Batch"] != null)
                {
                    model.Batch = row["Batch"].ToString();
                }
            }
            return model;
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

