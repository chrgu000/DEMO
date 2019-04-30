using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
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
        public string Add(TH.clsU8.Model.SO_SOMain model)
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
            //if (model.ufts != null)
            //{
            //    strSql1.Append("ufts,");
            //    strSql2.Append("" + model.ufts + ",");
            //}
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
            if (model.coppcode != null)
            {
                strSql1.Append("coppcode,");
                strSql2.Append("'" + model.coppcode + "',");
            }
            if (model.cLocker != null)
            {
                strSql1.Append("cLocker,");
                strSql2.Append("'" + model.cLocker + "',");
            }
            if (model.dPreMoDateBT != null)
            {
                strSql1.Append("dPreMoDateBT,");
                strSql2.Append("'" + model.dPreMoDateBT + "',");
            }
            if (model.dPreDateBT != null)
            {
                strSql1.Append("dPreDateBT,");
                strSql2.Append("'" + model.dPreDateBT + "',");
            }
            if (model.cgatheringplan != null)
            {
                strSql1.Append("cgatheringplan,");
                strSql2.Append("'" + model.cgatheringplan + "',");
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
            if (model.cgathingcode != null)
            {
                strSql1.Append("cgathingcode,");
                strSql2.Append("'" + model.cgathingcode + "',");
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
            if (model.outid != null)
            {
                strSql1.Append("outid,");
                strSql2.Append("'" + Guid.NewGuid().ToString() + "',");
            }
            if (model.ccuspersoncode != null)
            {
                strSql1.Append("ccuspersoncode,");
                strSql2.Append("'" + model.ccuspersoncode + "',");
            }
            if (model.dclosedate != null)
            {
                strSql1.Append("dclosedate,");
                strSql2.Append("'" + model.dclosedate + "',");
            }
            if (model.dclosesystime != null)
            {
                strSql1.Append("dclosesystime,");
                strSql2.Append("'" + model.dclosesystime + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.fbookratio != null)
            {
                strSql1.Append("fbookratio,");
                strSql2.Append("" + model.fbookratio + ",");
            }
            if (model.bmustbook != null)
            {
                strSql1.Append("bmustbook,");
                strSql2.Append("" + (model.bmustbook ? 1 : 0) + ",");
            }
            if (model.fbooksum != null)
            {
                strSql1.Append("fbooksum,");
                strSql2.Append("" + model.fbooksum + ",");
            }
            if (model.fbooknatsum != null)
            {
                strSql1.Append("fbooknatsum,");
                strSql2.Append("" + model.fbooknatsum + ",");
            }
            if (model.fgbooksum != null)
            {
                strSql1.Append("fgbooksum,");
                strSql2.Append("" + model.fgbooksum + ",");
            }
            if (model.fgbooknatsum != null)
            {
                strSql1.Append("fgbooknatsum,");
                strSql2.Append("" + model.fgbooknatsum + ",");
            }
            if (model.csvouchtype != null)
            {
                strSql1.Append("csvouchtype,");
                strSql2.Append("'" + model.csvouchtype + "',");
            }
            if (model.cCrmPersonCode != null)
            {
                strSql1.Append("cCrmPersonCode,");
                strSql2.Append("'" + model.cCrmPersonCode + "',");
            }
            if (model.cCrmPersonName != null)
            {
                strSql1.Append("cCrmPersonName,");
                strSql2.Append("'" + model.cCrmPersonName + "',");
            }
            if (model.cMainPersonCode != null)
            {
                strSql1.Append("cMainPersonCode,");
                strSql2.Append("'" + model.cMainPersonCode + "',");
            }
            if (model.cSysBarCode != null)
            {
                strSql1.Append("cSysBarCode,");
                strSql2.Append("'" + model.cSysBarCode + "',");
            }
            if (model.ioppid != null)
            {
                strSql1.Append("ioppid,");
                strSql2.Append("" + model.ioppid + ",");
            }
            if (model.optnty_name != null)
            {
                strSql1.Append("optnty_name,");
                strSql2.Append("'" + model.optnty_name + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.contract_status != null)
            {
                strSql1.Append("contract_status,");
                strSql2.Append("" + model.contract_status + ",");
            }
            if (model.csscode != null)
            {
                strSql1.Append("csscode,");
                strSql2.Append("'" + model.csscode + "',");
            }
            if (model.cinvoicecompany != null)
            {
                strSql1.Append("cinvoicecompany,");
                strSql2.Append("'" + model.cinvoicecompany + "',");
            }
            if (model.cAttachment != null)
            {
                strSql1.Append("cAttachment,");
                strSql2.Append("'" + model.cAttachment + "',");
            }
            strSql.Append("insert into SO_SOMain(");
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

