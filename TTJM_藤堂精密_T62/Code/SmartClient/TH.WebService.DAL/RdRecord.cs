using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:RdRecord
    /// </summary>
    public partial class RdRecord
    {
        public RdRecord()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.RdRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.bRdFlag != null)
            {
                strSql1.Append("bRdFlag,");
                strSql2.Append("" + model.bRdFlag + ",");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cBusCode != null)
            {
                strSql1.Append("cBusCode,");
                strSql2.Append("'" + model.cBusCode + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cOrderCode != null)
            {
                strSql1.Append("cOrderCode,");
                strSql2.Append("'" + model.cOrderCode + "',");
            }
            if (model.cARVCode != null)
            {
                strSql1.Append("cARVCode,");
                strSql2.Append("'" + model.cARVCode + "',");
            }
            if (model.cBillCode != null)
            {
                strSql1.Append("cBillCode,");
                strSql2.Append("" + model.cBillCode + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("" + model.cDLCode + ",");
            }
            if (model.cProBatch != null)
            {
                strSql1.Append("cProBatch,");
                strSql2.Append("'" + model.cProBatch + "',");
            }
            if (model.cHandler != null)
            {
                strSql1.Append("cHandler,");
                strSql2.Append("'" + model.cHandler + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.bTransFlag != null)
            {
                strSql1.Append("bTransFlag,");
                strSql2.Append("" + (model.bTransFlag ? 1 : 0) + ",");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.iNetLock != null)
            {
                strSql1.Append("iNetLock,");
                strSql2.Append("" + model.iNetLock + ",");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.dKeepDate != null)
            {
                strSql1.Append("dKeepDate,");
                strSql2.Append("'" + model.dKeepDate + "',");
            }
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.bpufirst != null)
            {
                strSql1.Append("bpufirst,");
                strSql2.Append("" + (model.bpufirst ? 1 : 0) + ",");
            }
            if (model.biafirst != null)
            {
                strSql1.Append("biafirst,");
                strSql2.Append("" + (model.biafirst ? 1 : 0) + ",");
            }
            if (model.iMQuantity != null)
            {
                strSql1.Append("iMQuantity,");
                strSql2.Append("" + model.iMQuantity + ",");
            }
            if (model.dARVDate != null)
            {
                strSql1.Append("dARVDate,");
                strSql2.Append("'" + model.dARVDate + "',");
            }
            if (model.cChkCode != null)
            {
                strSql1.Append("cChkCode,");
                strSql2.Append("'" + model.cChkCode + "',");
            }
            if (model.dChkDate != null)
            {
                strSql1.Append("dChkDate,");
                strSql2.Append("'" + model.dChkDate + "',");
            }
            if (model.cChkPerson != null)
            {
                strSql1.Append("cChkPerson,");
                strSql2.Append("'" + model.cChkPerson + "',");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.bIsSTQc != null)
            {
                strSql1.Append("bIsSTQc,");
                strSql2.Append("" + (model.bIsSTQc ? 1 : 0) + ",");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            if (model.cPsPcode != null)
            {
                strSql1.Append("cPsPcode,");
                strSql2.Append("'" + model.cPsPcode + "',");
            }
            if (model.cMPoCode != null)
            {
                strSql1.Append("cMPoCode,");
                strSql2.Append("'" + model.cMPoCode + "',");
            }
            if (model.gspcheck != null)
            {
                strSql1.Append("gspcheck,");
                strSql2.Append("'" + model.gspcheck + "',");
            }
            if (model.ipurorderid != null)
            {
                strSql1.Append("ipurorderid,");
                strSql2.Append("" + model.ipurorderid + ",");
            }
            if (model.ipurarriveid != null)
            {
                strSql1.Append("ipurarriveid,");
                strSql2.Append("" + model.ipurarriveid + ",");
            }
            if (model.iproorderid != null)
            {
                strSql1.Append("iproorderid,");
                strSql2.Append("" + model.iproorderid + ",");
            }
            if (model.iarriveid != null)
            {
                strSql1.Append("iarriveid,");
                strSql2.Append("'" + model.iarriveid + "',");
            }
            if (model.isalebillid != null)
            {
                strSql1.Append("isalebillid,");
                strSql2.Append("'" + model.isalebillid + "',");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.cBomSoCode != null)
            {
                strSql1.Append("cBomSoCode,");
                strSql2.Append("'" + model.cBomSoCode + "',");
            }
            if (model.cOMrdType != null)
            {
                strSql1.Append("cOMrdType,");
                strSql2.Append("'" + model.cOMrdType + "',");
            }
            if (model.cBusCode2 != null)
            {
                strSql1.Append("cBusCode2,");
                strSql2.Append("'" + model.cBusCode2 + "',");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.cAccountPID != null)
            {
                strSql1.Append("cAccountPID,");
                strSql2.Append("'" + model.cAccountPID + "',");
            }
            if (model.cAccountPDate != null)
            {
                strSql1.Append("cAccountPDate,");
                strSql2.Append("'" + model.cAccountPDate + "',");
            }
            if (model.cPayCode != null)
            {
                strSql1.Append("cPayCode,");
                strSql2.Append("'" + model.cPayCode + "',");
            }
            if (model.bgxljz != null)
            {
                strSql1.Append("bgxljz,");
                strSql2.Append("" + (model.bgxljz ? 1 : 0) + ",");
            }
            if (model.bisomqc != null)
            {
                strSql1.Append("bisomqc,");
                strSql2.Append("" + (model.bisomqc ? 1 : 0) + ",");
            }
            if (model.cvenbank != null)
            {
                strSql1.Append("cvenbank,");
                strSql2.Append("'" + model.cvenbank + "',");
            }
            if (model.cvenaddress != null)
            {
                strSql1.Append("cvenaddress,");
                strSql2.Append("'" + model.cvenaddress + "',");
            }
            if (model.cvenphone != null)
            {
                strSql1.Append("cvenphone,");
                strSql2.Append("'" + model.cvenphone + "',");
            }
            if (model.cvenfax != null)
            {
                strSql1.Append("cvenfax,");
                strSql2.Append("'" + model.cvenfax + "',");
            }
            if (model.cvenpostcode != null)
            {
                strSql1.Append("cvenpostcode,");
                strSql2.Append("'" + model.cvenpostcode + "',");
            }
            if (model.cvenperson != null)
            {
                strSql1.Append("cvenperson,");
                strSql2.Append("'" + model.cvenperson + "',");
            }
            if (model.cvenaccount != null)
            {
                strSql1.Append("cvenaccount,");
                strSql2.Append("'" + model.cvenaccount + "',");
            }
            if (model.cvenregcode != null)
            {
                strSql1.Append("cvenregcode,");
                strSql2.Append("'" + model.cvenregcode + "',");
            }
            if (model.cAlter != null)
            {
                strSql1.Append("cAlter,");
                strSql2.Append("'" + model.cAlter + "',");
            }
            strSql.Append("insert into @u8.RdRecord(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

