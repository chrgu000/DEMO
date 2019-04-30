using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 数据访问类:SaleBillVouch
    /// </summary>
    public partial class SaleBillVouch
    {
        public SaleBillVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.SaleBillVouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.SBVID != null)
            {
                strSql1.Append("SBVID,");
                strSql2.Append("" + model.SBVID + ",");
            }
            if (model.cSBVCode != null)
            {
                strSql1.Append("cSBVCode,");
                strSql2.Append("'" + model.cSBVCode + "',");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cSaleOut != null)
            {
                strSql1.Append("cSaleOut,");
                strSql2.Append("'" + model.cSaleOut + "',");
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
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cPayCode != null)
            {
                strSql1.Append("cPayCode,");
                strSql2.Append("'" + model.cPayCode + "',");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.iExchRate != null)
            {
                strSql1.Append("iExchRate,");
                strSql2.Append("" + model.iExchRate + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.bReturnFlag != null)
            {
                strSql1.Append("bReturnFlag,");
                strSql2.Append("" + (model.bReturnFlag ? 1 : 0) + ",");
            }
            if (model.cBCode != null)
            {
                strSql1.Append("cBCode,");
                strSql2.Append("'" + model.cBCode + "',");
            }
            if (model.cBillVer != null)
            {
                strSql1.Append("cBillVer,");
                strSql2.Append("'" + model.cBillVer + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.cInvalider != null)
            {
                strSql1.Append("cInvalider,");
                strSql2.Append("'" + model.cInvalider + "',");
            }
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.bFirst != null)
            {
                strSql1.Append("bFirst,");
                strSql2.Append("" + (model.bFirst ? 1 : 0) + ",");
            }
            if (model.citem_class != null)
            {
                strSql1.Append("citem_class,");
                strSql2.Append("'" + model.citem_class + "',");
            }
            if (model.citemcode != null)
            {
                strSql1.Append("citemcode,");
                strSql2.Append("'" + model.citemcode + "',");
            }
            if (model.cHeadCode != null)
            {
                strSql1.Append("cHeadCode,");
                strSql2.Append("'" + model.cHeadCode + "',");
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
            if (model.bPayMent != null)
            {
                strSql1.Append("bPayMent,");
                strSql2.Append("'" + model.bPayMent + "',");
            }
            if (model.iDisp != null)
            {
                strSql1.Append("iDisp,");
                strSql2.Append("" + model.iDisp + ",");
            }
            if (model.cCusName != null)
            {
                strSql1.Append("cCusName,");
                strSql2.Append("'" + model.cCusName + "',");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("'" + model.cDLCode + "',");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cChecker != null)
            {
                strSql1.Append("cChecker,");
                strSql2.Append("'" + model.cChecker + "',");
            }
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.bIAFirst != null)
            {
                strSql1.Append("bIAFirst,");
                strSql2.Append("" + (model.bIAFirst ? 1 : 0) + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.cCreChpName != null)
            {
                strSql1.Append("cCreChpName,");
                strSql2.Append("'" + model.cCreChpName + "',");
            }
            if (model.cInfoTypeCode != null)
            {
                strSql1.Append("cInfoTypeCode,");
                strSql2.Append("'" + model.cInfoTypeCode + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
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
            if (model.cAccountPID != null)
            {
                strSql1.Append("cAccountPID,");
                strSql2.Append("'" + model.cAccountPID + "',");
            }
            if (model.ccusoaddress != null)
            {
                strSql1.Append("ccusoaddress,");
                strSql2.Append("'" + model.ccusoaddress + "',");
            }
            if (model.csccode != null)
            {
                strSql1.Append("csccode,");
                strSql2.Append("'" + model.csccode + "',");
            }
            if (model.cscname != null)
            {
                strSql1.Append("cscname,");
                strSql2.Append("'" + model.cscname + "',");
            }
            strSql.Append("insert into SaleBillVouch(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

