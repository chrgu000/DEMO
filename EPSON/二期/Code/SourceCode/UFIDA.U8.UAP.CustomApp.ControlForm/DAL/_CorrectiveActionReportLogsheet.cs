using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_CorrectiveActionReportLogsheet
    /// </summary>
    public partial class _CorrectiveActionReportLogsheet
    {
        public _CorrectiveActionReportLogsheet()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._CorrectiveActionReportLogsheet model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.Barcode != null)
            {
                strSql1.Append("Barcode,");
                strSql2.Append("'" + model.Barcode + "',");
            }
            if (model.ReportNo != null)
            {
                strSql1.Append("ReportNo,");
                strSql2.Append("'" + model.ReportNo + "',");
            }
            if (model.DateofComplaint != null)
            {
                strSql1.Append("DateofComplaint,");
                strSql2.Append("'" + model.DateofComplaint + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.Description != null)
            {
                strSql1.Append("Description,");
                strSql2.Append("'" + model.Description + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.DateIssued != null)
            {
                strSql1.Append("DateIssued,");
                strSql2.Append("'" + model.DateIssued + "',");
            }
            if (model.DueDate != null)
            {
                strSql1.Append("DueDate,");
                strSql2.Append("'" + model.DueDate + "',");
            }
            if (model.DateReplied != null)
            {
                strSql1.Append("DateReplied,");
                strSql2.Append("'" + model.DateReplied + "',");
            }
            if (model.DateClosed != null)
            {
                strSql1.Append("DateClosed,");
                strSql2.Append("'" + model.DateClosed + "',");
            }
            if (model.Remarks != null)
            {
                strSql1.Append("Remarks,");
                strSql2.Append("'" + model.Remarks + "',");
            }
            if (model.Complaint != null)
            {
                strSql1.Append("Complaint,");
                strSql2.Append("" + model.Complaint + ",");
            }
            if (model.Claim != null)
            {
                strSql1.Append("Claim,");
                strSql2.Append("" + model.Claim + ",");
            }
            strSql.Append("insert into _CorrectiveActionReportLogsheet(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._CorrectiveActionReportLogsheet model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _CorrectiveActionReportLogsheet set ");
            if (model.sType != null)
            {
                strSql.Append("sType='" + model.sType + "',");
            }
            else
            {
                strSql.Append("sType= null ,");
            }
            if (model.Barcode != null)
            {
                strSql.Append("Barcode='" + model.Barcode + "',");
            }
            else
            {
                strSql.Append("Barcode= null ,");
            }
            if (model.ReportNo != null)
            {
                strSql.Append("ReportNo='" + model.ReportNo + "',");
            }
            else
            {
                strSql.Append("ReportNo= null ,");
            }
            if (model.DateofComplaint != null)
            {
                strSql.Append("DateofComplaint='" + model.DateofComplaint + "',");
            }
            else
            {
                strSql.Append("DateofComplaint= null ,");
            }
            if (model.cCusCode != null)
            {
                strSql.Append("cCusCode='" + model.cCusCode + "',");
            }
            else
            {
                strSql.Append("cCusCode= null ,");
            }
            if (model.Description != null)
            {
                strSql.Append("Description='" + model.Description + "',");
            }
            else
            {
                strSql.Append("Description= null ,");
            }
            if (model.cDepCode != null)
            {
                strSql.Append("cDepCode='" + model.cDepCode + "',");
            }
            else
            {
                strSql.Append("cDepCode= null ,");
            }
            if (model.DateIssued != null)
            {
                strSql.Append("DateIssued='" + model.DateIssued + "',");
            }
            else
            {
                strSql.Append("DateIssued= null ,");
            }
            if (model.DueDate != null)
            {
                strSql.Append("DueDate='" + model.DueDate + "',");
            }
            else
            {
                strSql.Append("DueDate= null ,");
            }
            if (model.DateReplied != null)
            {
                strSql.Append("DateReplied='" + model.DateReplied + "',");
            }
            else
            {
                strSql.Append("DateReplied= null ,");
            }
            if (model.DateClosed != null)
            {
                strSql.Append("DateClosed='" + model.DateClosed + "',");
            }
            else
            {
                strSql.Append("DateClosed= null ,");
            }
            if (model.Remarks != null)
            {
                strSql.Append("Remarks='" + model.Remarks + "',");
            }
            else
            {
                strSql.Append("Remarks= null ,");
            }
            if (model.Complaint != null)
            {
                strSql.Append("Complaint=" + model.Complaint + ",");
            }
            else
            {
                strSql.Append("Complaint= null ,");
            }
            if (model.Claim != null)
            {
                strSql.Append("Claim=" + model.Claim + ",");
            }
            else
            {
                strSql.Append("Claim= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

