using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:OM_MOMain
    /// </summary>
    public partial class OM_MOMain
    {
        public OM_MOMain()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.OM_MOMain model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MOID != null)
            {
                strSql1.Append("MOID,");
                strSql2.Append("" + model.MOID + ",");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
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
            if (model.cArrivalPlace != null)
            {
                strSql1.Append("cArrivalPlace,");
                strSql2.Append("'" + model.cArrivalPlace + "',");
            }
            if (model.cSCCode != null)
            {
                strSql1.Append("cSCCode,");
                strSql2.Append("'" + model.cSCCode + "',");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.nflat != null)
            {
                strSql1.Append("nflat,");
                strSql2.Append("" + model.nflat + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.cPayCode != null)
            {
                strSql1.Append("cPayCode,");
                strSql2.Append("'" + model.cPayCode + "',");
            }
            if (model.iCost != null)
            {
                strSql1.Append("iCost,");
                strSql2.Append("" + model.iCost + ",");
            }
            if (model.iBargain != null)
            {
                strSql1.Append("iBargain,");
                strSql2.Append("" + model.iBargain + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.cCloser != null)
            {
                strSql1.Append("cCloser,");
                strSql2.Append("'" + model.cCloser + "',");
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
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.cChanger != null)
            {
                strSql1.Append("cChanger,");
                strSql2.Append("'" + model.cChanger + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
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
            if (model.cLocker != null)
            {
                strSql1.Append("cLocker,");
                strSql2.Append("'" + model.cLocker + "',");
            }
            if (model.cState != null)
            {
                strSql1.Append("cState,");
                strSql2.Append("" + model.cState + ",");
            }
            if (model.iReturnCount != null)
            {
                strSql1.Append("iReturnCount,");
                strSql2.Append("" + model.iReturnCount + ",");
            }
            if (model.iVerifyStateNew != null)
            {
                strSql1.Append("iVerifyStateNew,");
                strSql2.Append("" + model.iVerifyStateNew + ",");
            }
            if (model.IsWfControlled != null)
            {
                strSql1.Append("IsWfControlled,");
                strSql2.Append("" + model.IsWfControlled + ",");
            }
            if (model.cModifier != null)
            {
                strSql1.Append("cModifier,");
                strSql2.Append("'" + model.cModifier + "',");
            }
            if (model.dCreateTime != null)
            {
                strSql1.Append("dCreateTime,");
                strSql2.Append("'" + model.dCreateTime + "',");
            }
            if (model.dModifyDate != null)
            {
                strSql1.Append("dModifyDate,");
                strSql2.Append("'" + model.dModifyDate + "',");
            }
            if (model.dModifyTime != null)
            {
                strSql1.Append("dModifyTime,");
                strSql2.Append("'" + model.dModifyTime + "',");
            }
            if (model.dVerifyDate != null)
            {
                strSql1.Append("dVerifyDate,");
                strSql2.Append("'" + model.dVerifyDate + "',");
            }
            if (model.dVerifyTime != null)
            {
                strSql1.Append("dVerifyTime,");
                strSql2.Append("'" + model.dVerifyTime + "',");
            }
            if (model.dAlterTime != null)
            {
                strSql1.Append("dAlterTime,");
                strSql2.Append("'" + model.dAlterTime + "',");
            }
            if (model.cChangeVerifier != null)
            {
                strSql1.Append("cChangeVerifier,");
                strSql2.Append("'" + model.cChangeVerifier + "',");
            }
            if (model.dChangeVerifyDate != null)
            {
                strSql1.Append("dChangeVerifyDate,");
                strSql2.Append("'" + model.dChangeVerifyDate + "',");
            }
            if (model.dChangeVerifyTime != null)
            {
                strSql1.Append("dChangeVerifyTime,");
                strSql2.Append("'" + model.dChangeVerifyTime + "',");
            }
            if (model.cVenPUOMProtocol != null)
            {
                strSql1.Append("cVenPUOMProtocol,");
                strSql2.Append("'" + model.cVenPUOMProtocol + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.dCloseDate != null)
            {
                strSql1.Append("dCloseDate,");
                strSql2.Append("'" + model.dCloseDate + "',");
            }
            if (model.dCloseTime != null)
            {
                strSql1.Append("dCloseTime,");
                strSql2.Append("'" + model.dCloseTime + "',");
            }
            if (model.ccleanver != null)
            {
                strSql1.Append("ccleanver,");
                strSql2.Append("'" + model.ccleanver + "',");
            }
            if (model.cContactCode != null)
            {
                strSql1.Append("cContactCode,");
                strSql2.Append("'" + model.cContactCode + "',");
            }
            if (model.cVenPerson != null)
            {
                strSql1.Append("cVenPerson,");
                strSql2.Append("'" + model.cVenPerson + "',");
            }
            if (model.cVenBank != null)
            {
                strSql1.Append("cVenBank,");
                strSql2.Append("'" + model.cVenBank + "',");
            }
            if (model.cVenAccount != null)
            {
                strSql1.Append("cVenAccount,");
                strSql2.Append("'" + model.cVenAccount + "',");
            }
            if (model.csrccode != null)
            {
                strSql1.Append("csrccode,");
                strSql2.Append("'" + model.csrccode + "',");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.iOrderType != null)
            {
                strSql1.Append("iOrderType,");
                strSql2.Append("" + model.iOrderType + ",");
            }
            if (model.bRework != null)
            {
                strSql1.Append("bRework,");
                strSql2.Append("" + model.bRework + ",");
            }
            strSql.Append("insert into @u8.OM_MOMain(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

