using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:SO_SOMain
    /// </summary>
    public partial class SO_SOMain
    {
        public SO_SOMain()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.SO_SOMain model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
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
            if (model.cSCCode != null)
            {
                strSql1.Append("cSCCode,");
                strSql2.Append("'" + model.cSCCode + "',");
            }
            if (model.cCusOAddress != null)
            {
                strSql1.Append("cCusOAddress,");
                strSql2.Append("'" + model.cCusOAddress + "',");
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
            if (model.iMoney != null)
            {
                strSql1.Append("iMoney,");
                strSql2.Append("" + model.iMoney + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.iStatus != null)
            {
                strSql1.Append("iStatus,");
                strSql2.Append("" + model.iStatus + ",");
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
            if (model.bDisFlag != null)
            {
                strSql1.Append("bDisFlag,");
                strSql2.Append("" + (model.bDisFlag ? 1 : 0) + ",");
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
            if (model.bReturnFlag != null)
            {
                strSql1.Append("bReturnFlag,");
                strSql2.Append("" + (model.bReturnFlag ? 1 : 0) + ",");
            }
            if (model.cCusName != null)
            {
                strSql1.Append("cCusName,");
                strSql2.Append("'" + model.cCusName + "',");
            }
            if (model.bOrder != null)
            {
                strSql1.Append("bOrder,");
                strSql2.Append("" + (model.bOrder ? 1 : 0) + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.iVTid != null)
            {
                strSql1.Append("iVTid,");
                strSql2.Append("" + model.iVTid + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
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
            if (model.cCreChpName != null)
            {
                strSql1.Append("cCreChpName,");
                strSql2.Append("'" + model.cCreChpName + "',");
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
            if (model.cAccountPDate != null)
            {
                strSql1.Append("cAccountPDate,");
                strSql2.Append("'" + model.cAccountPDate + "',");
            }
            if (model.defaultcall != null)
            {
                strSql1.Append("defaultcall,");
                strSql2.Append("'" + model.defaultcall + "',");
            }
            if (model.coutverifier != null)
            {
                strSql1.Append("coutverifier,");
                strSql2.Append("'" + model.coutverifier + "',");
            }
            if (model.coutcontrol != null)
            {
                strSql1.Append("coutcontrol,");
                strSql2.Append("'" + model.coutcontrol + "',");
            }
            if (model.coutstatus != null)
            {
                strSql1.Append("coutstatus,");
                strSql2.Append("'" + model.coutstatus + "',");
            }
            if (model.dcoutveriddate != null)
            {
                strSql1.Append("dcoutveriddate,");
                strSql2.Append("'" + model.dcoutveriddate + "',");
            }
            strSql.Append("insert into @u8.SO_SOMain(");
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

