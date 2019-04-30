using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_OQC_RMDF
    /// </summary>
    public partial class _OQC_RMDF
    {
        public _OQC_RMDF()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._OQC_RMDF model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.OQCNo != null)
            {
                strSql1.Append("OQCNo,");
                strSql2.Append("'" + model.OQCNo + "',");
            }
            if (model.OQCStatus != null)
            {
                strSql1.Append("OQCStatus,");
                strSql2.Append("'" + model.OQCStatus + "',");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.LotNo != null)
            {
                strSql1.Append("LotNo,");
                strSql2.Append("'" + model.LotNo + "',");
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
            if (model.sStatus != null)
            {
                strSql1.Append("sStatus,");
                strSql2.Append("" + model.sStatus + ",");
            }
            if (model.Action != null)
            {
                strSql1.Append("Action,");
                strSql2.Append("'" + model.Action + "',");
            }
            if (model.LotQty != null)
            {
                strSql1.Append("LotQty,");
                strSql2.Append("" + model.LotQty + ",");
            }
            if (model.InsQty != null)
            {
                strSql1.Append("InsQty,");
                strSql2.Append("" + model.InsQty + ",");
            }
            if (model.SampleSize != null)
            {
                strSql1.Append("SampleSize,");
                strSql2.Append("" + model.SampleSize + ",");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.AQLLevel != null)
            {
                strSql1.Append("AQLLevel,");
                strSql2.Append("'" + model.AQLLevel + "',");
            }
            if (model.Accept != null)
            {
                strSql1.Append("Accept,");
                strSql2.Append("" + model.Accept + ",");
            }
            if (model.Reject != null)
            {
                strSql1.Append("Reject,");
                strSql2.Append("" + model.Reject + ",");
            }
            if (model.Result != null)
            {
                strSql1.Append("result,");
                strSql2.Append("'" + model.Result + "',");
            }
            if (model.dtmReceived != null)
            {
                strSql1.Append("dtmReceived,");
                strSql2.Append("'" + model.dtmReceived + "',");
            }
            if (model.dtmInspected != null)
            {
                strSql1.Append("dtmInspected,");
                strSql2.Append("'" + model.dtmInspected + "',");
            }
            if (model.InspectedBy != null)
            {
                strSql1.Append("InspectedBy,");
                strSql2.Append("'" + model.InspectedBy + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.dtmUpdate != null)
            {
                strSql1.Append("dtmUpdate,");
                strSql2.Append("'" + model.dtmUpdate + "',");
            }
            if (model.AuditUid != null)
            {
                strSql1.Append("AuditUid,");
                strSql2.Append("'" + model.AuditUid + "',");
            }
            if (model.dtmAudit != null)
            {
                strSql1.Append("dtmAudit,");
                strSql2.Append("'" + model.dtmAudit + "',");
            }
            if (model.SendMailCount != null)
            {
                strSql1.Append("SendMailCount,");
                strSql2.Append("" + model.SendMailCount + ",");
            }
            if (model.SendMailUid != null)
            {
                strSql1.Append("SendMailUid,");
                strSql2.Append("'" + model.SendMailUid + "',");
            }
            if (model.dtmSendMail != null)
            {
                strSql1.Append("dtmSendMail,");
                strSql2.Append("'" + model.dtmSendMail + "',");
            }
            if (model.Feedback != null)
            {
                strSql1.Append("Feedback,");
                strSql2.Append("'" + model.Feedback + "',");
            }
            if (model.SaveCount != null)
            {
                strSql1.Append("SaveCount,");
                strSql2.Append("" + model.SaveCount + ",");
            }
            if (model.Process != null)
            {
                strSql1.Append("Process,");
                strSql2.Append("'" + model.Process + "',");
            }
            if (model.ClosedUid != null)
            {
                strSql1.Append("ClosedUid,");
                strSql2.Append("'" + model.ClosedUid + "',");
            }
            if (model.dtmClose != null)
            {
                strSql1.Append("dtmClose,");
                strSql2.Append("'" + model.dtmClose + "',");
            }
            if (model.Plater != null)
            {
                strSql1.Append("Plater,");
                strSql2.Append("'" + model.Plater + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            
            strSql.Append("insert into _OQC_RMDF(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._OQC_RMDF model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _OQC_RMDF set ");
            if (model.OQCStatus != null)
            {
                strSql.Append("OQCStatus='" + model.OQCStatus + "',");
            }
            else
            {
                strSql.Append("OQCStatus= null ,");
            }
            if (model.iSOsID != null)
            {
                strSql.Append("iSOsID=" + model.iSOsID + ",");
            }
            else
            {
                strSql.Append("iSOsID= null ,");
            }
            if (model.LotNo != null)
            {
                strSql.Append("LotNo='" + model.LotNo + "',");
            }
            else
            {
                strSql.Append("LotNo= null ,");
            }
            if (model.cInvCode != null)
            {
                strSql.Append("cInvCode='" + model.cInvCode + "',");
            }
            else
            {
                strSql.Append("cInvCode= null ,");
            }
            if (model.cInvName != null)
            {
                strSql.Append("cInvName='" + model.cInvName + "',");
            }
            else
            {
                strSql.Append("cInvName= null ,");
            }
            if (model.sStatus != null)
            {
                strSql.Append("sStatus=" + model.sStatus + ",");
            }
            else
            {
                strSql.Append("sStatus= null ,");
            }
            if (model.Action != null)
            {
                strSql.Append("Action='" + model.Action + "',");
            }
            else
            {
                strSql.Append("Action= null ,");
            }
            if (model.LotQty != null)
            {
                strSql.Append("LotQty=" + model.LotQty + ",");
            }
            else
            {
                strSql.Append("LotQty= null ,");
            }
            if (model.InsQty != null)
            {
                strSql.Append("InsQty=" + model.InsQty + ",");
            }
            else
            {
                strSql.Append("InsQty= null ,");
            }
            if (model.SampleSize != null)
            {
                strSql.Append("SampleSize=" + model.SampleSize + ",");
            }
            else
            {
                strSql.Append("SampleSize= null ,");
            }
            if (model.cCusCode != null)
            {
                strSql.Append("cCusCode='" + model.cCusCode + "',");
            }
            else
            {
                strSql.Append("cCusCode= null ,");
            }
            if (model.AQLLevel != null)
            {
                strSql.Append("AQLLevel='" + model.AQLLevel + "',");
            }
            else
            {
                strSql.Append("AQLLevel= null ,");
            }
            if (model.Accept != null)
            {
                strSql.Append("Accept=" + model.Accept + ",");
            }
            else
            {
                strSql.Append("Accept= null ,");
            }
            if (model.Reject != null)
            {
                strSql.Append("Reject=" + model.Reject + ",");
            }
            else
            {
                strSql.Append("Reject= null ,");
            }
            if (model.Result != null)
            {
                strSql.Append("result='" + model.Result + "',");
            }
            else
            {
                strSql.Append("result= null ,");
            }
            if (model.dtmReceived != null)
            {
                strSql.Append("dtmReceived='" + model.dtmReceived + "',");
            }
            else
            {
                strSql.Append("dtmReceived= null ,");
            }
            if (model.dtmInspected != null)
            {
                strSql.Append("dtmInspected='" + model.dtmInspected + "',");
            }
            else
            {
                strSql.Append("dtmInspected= null ,");
            }
            if (model.InspectedBy != null)
            {
                strSql.Append("InspectedBy='" + model.InspectedBy + "',");
            }
            else
            {
                strSql.Append("InspectedBy= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
            }
            if (model.UpdateUid != null)
            {
                strSql.Append("UpdateUid='" + model.UpdateUid + "',");
            }
            else
            {
                strSql.Append("UpdateUid= null ,");
            }
            if (model.dtmUpdate != null)
            {
                strSql.Append("dtmUpdate='" + model.dtmUpdate + "',");
            }
            else
            {
                strSql.Append("dtmUpdate= null ,");
            }
            if (model.AuditUid != null)
            {
                strSql.Append("AuditUid='" + model.AuditUid + "',");
            }
            else
            {
                strSql.Append("AuditUid= null ,");
            }
            if (model.dtmAudit != null)
            {
                strSql.Append("dtmAudit='" + model.dtmAudit + "',");
            }
            else
            {
                strSql.Append("dtmAudit= null ,");
            }
            if (model.SendMailCount != null)
            {
                strSql.Append("SendMailCount=" + model.SendMailCount + ",");
            }
            else
            {
                strSql.Append("SendMailCount= null ,");
            }
            if (model.SendMailUid != null)
            {
                strSql.Append("SendMailUid='" + model.SendMailUid + "',");
            }
            else
            {
                strSql.Append("SendMailUid= null ,");
            }
            if (model.dtmSendMail != null)
            {
                strSql.Append("dtmSendMail='" + model.dtmSendMail + "',");
            }
            else
            {
                strSql.Append("dtmSendMail= null ,");
            }
            if (model.Feedback != null)
            {
                strSql.Append("Feedback='" + model.Feedback + "',");
            }
            else
            {
                strSql.Append("Feedback= null ,");
            }
            if (model.SaveCount != null)
            {
                strSql.Append("SaveCount=" + model.SaveCount + ",");
            }
            else
            {
                strSql.Append("SaveCount= null ,");
            }
            if (model.Process != null)
            {
                strSql.Append("Process='" + model.Process + "',");
            }
            else
            {
                strSql.Append("Process= null ,");
            }
            if (model.ClosedUid != null)
            {
                strSql.Append("ClosedUid='" + model.ClosedUid + "',");
            }
            else
            {
                strSql.Append("ClosedUid= null ,");
            }
            if (model.dtmClose != null)
            {
                strSql.Append("dtmClose='" + model.dtmClose + "',");
            }
            else
            {
                strSql.Append("dtmClose= null ,");
            }
            if (model.Plater != null)
            {
                strSql.Append("Plater='" + model.Plater + "',");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where OQCNo='" + model.OQCNo + "'");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _OQC_RMDF ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string RMDFNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _OQC_RMDF ");
            strSql.Append(" where RMDFNo=" + RMDFNo + "");
            return (strSql.ToString());
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

