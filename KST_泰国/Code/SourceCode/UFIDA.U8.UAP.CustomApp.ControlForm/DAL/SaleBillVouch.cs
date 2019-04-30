using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
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
            if (model.cSCCode != null)
            {
                strSql1.Append("cSCCode,");
                strSql2.Append("'" + model.cSCCode + "',");
            }
            if (model.cShipAddress != null)
            {
                strSql1.Append("cShipAddress,");
                strSql2.Append("'" + model.cShipAddress + "',");
            }
            if (model.ccusbank != null)
            {
                strSql1.Append("ccusbank,");
                strSql2.Append("'" + model.ccusbank + "',");
            }
            if (model.ccusaccount != null)
            {
                strSql1.Append("ccusaccount,");
                strSql2.Append("'" + model.ccusaccount + "',");
            }
            if (model.ioutgolden != null)
            {
                strSql1.Append("ioutgolden,");
                strSql2.Append("" + model.ioutgolden + ",");
            }
            if (model.cgatheringplan != null)
            {
                strSql1.Append("cgatheringplan,");
                strSql2.Append("'" + model.cgatheringplan + "',");
            }
            if (model.dCreditStart != null)
            {
                strSql1.Append("dCreditStart,");
                strSql2.Append("'" + model.dCreditStart + "',");
            }
            if (model.dGatheringDate != null)
            {
                strSql1.Append("dGatheringDate,");
                strSql2.Append("'" + model.dGatheringDate + "',");
            }
            if (model.icreditdays != null)
            {
                strSql1.Append("icreditdays,");
                strSql2.Append("" + model.icreditdays + ",");
            }
            if (model.bCredit != null)
            {
                strSql1.Append("bCredit,");
                strSql2.Append("" + (model.bCredit ? 1 : 0) + ",");
            }
            if (model.caddcode != null)
            {
                strSql1.Append("caddcode,");
                strSql2.Append("'" + model.caddcode + "',");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.icreditstate != null)
            {
                strSql1.Append("icreditstate,");
                strSql2.Append("'" + model.icreditstate + "',");
            }
            if (model.cmodifier != null)
            {
                strSql1.Append("cmodifier,");
                strSql2.Append("'" + model.cmodifier + "',");
            }
            if (model.dmoddate != null)
            {
                strSql1.Append("dmoddate,");
                strSql2.Append("'" + model.dmoddate + "',");
            }
            if (model.dverifydate != null)
            {
                strSql1.Append("dverifydate,");
                strSql2.Append("'" + model.dverifydate + "',");
            }
            if (model.ccusperson != null)
            {
                strSql1.Append("ccusperson,");
                strSql2.Append("'" + model.ccusperson + "',");
            }
            if (model.dcreatesystime != null)
            {
                strSql1.Append("dcreatesystime,");
                strSql2.Append("'" + model.dcreatesystime + "',");
            }
            if (model.dverifysystime != null)
            {
                strSql1.Append("dverifysystime,");
                strSql2.Append("'" + model.dverifysystime + "',");
            }
            if (model.dmodifysystime != null)
            {
                strSql1.Append("dmodifysystime,");
                strSql2.Append("'" + model.dmodifysystime + "',");
            }
            if (model.iflowid != null)
            {
                strSql1.Append("iflowid,");
                strSql2.Append("" + model.iflowid + ",");
            }
            if (model.bcashsale != null)
            {
                strSql1.Append("bcashsale,");
                strSql2.Append("" + (model.bcashsale ? 1 : 0) + ",");
            }
            if (model.retail_id != null)
            {
                strSql1.Append("retail_id,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.cBookDepcode != null)
            {
                strSql1.Append("cBookDepcode,");
                strSql2.Append("'" + model.cBookDepcode + "',");
            }
            if (model.cBookType != null)
            {
                strSql1.Append("cBookType,");
                strSql2.Append("'" + model.cBookType + "',");
            }
            if (model.ccuspersoncode != null)
            {
                strSql1.Append("ccuspersoncode,");
                strSql2.Append("'" + model.ccuspersoncode + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.dArverifydate != null)
            {
                strSql1.Append("dArverifydate,");
                strSql2.Append("'" + model.dArverifydate + "',");
            }
            if (model.dArverifysystime != null)
            {
                strSql1.Append("dArverifysystime,");
                strSql2.Append("'" + model.dArverifysystime + "',");
            }
            if (model.cSysBarCode != null)
            {
                strSql1.Append("cSysBarCode,");
                strSql2.Append("'" + model.cSysBarCode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.csscode != null)
            {
                strSql1.Append("csscode,");
                strSql2.Append("'" + model.csscode + "',");
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

