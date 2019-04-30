using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_高开返利单
    /// </summary>
    public partial class _高开返利单_SZ
    {
        public _高开返利单_SZ()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._高开返利单_SZ model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.dtmDate != null)
            {
                strSql1.Append("dtmDate,");
                strSql2.Append("'" + model.dtmDate + "',");
            }
            if (model.FPIDs != null)
            {
                strSql1.Append("FPIDs,");
                strSql2.Append("" + model.FPIDs + ",");
            }
            if (model.cSBVCode != null)
            {
                strSql1.Append("cSBVCode,");
                strSql2.Append("'" + model.cSBVCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cPersonCode != null)
            {
                strSql1.Append("cPersonCode,");
                strSql2.Append("'" + model.cPersonCode + "',");
            }
            if (model.cPersonName != null)
            {
                strSql1.Append("cPersonName,");
                strSql2.Append("'" + model.cPersonName + "',");
            }
            if (model.cDepCode != null)
            {
                strSql1.Append("cDepCode,");
                strSql2.Append("'" + model.cDepCode + "',");
            }
            if (model.cDepName != null)
            {
                strSql1.Append("cDepName,");
                strSql2.Append("'" + model.cDepName + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cCusName != null)
            {
                strSql1.Append("cCusName,");
                strSql2.Append("'" + model.cCusName + "',");
            }
            if (model.cCusAbbName != null)
            {
                strSql1.Append("cCusAbbName,");
                strSql2.Append("'" + model.cCusAbbName + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvAddCode != null)
            {
                strSql1.Append("cInvAddCode,");
                strSql2.Append("'" + model.cInvAddCode + "',");
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
            if (model.iTaxUnitPrice != null)
            {
                strSql1.Append("iTaxUnitPrice,");
                strSql2.Append("" + model.iTaxUnitPrice + ",");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("'" + model.cDLCode + "',");
            }
            if (model.iTaxUnitPriceFH != null)
            {
                strSql1.Append("iTaxUnitPriceFH,");
                strSql2.Append("" + model.iTaxUnitPriceFH + ",");
            }
            if (model.iTaxRateCJ != null)
            {
                strSql1.Append("iTaxRateCJ,");
                strSql2.Append("" + model.iTaxRateCJ + ",");
            }
            if (model.iTaxCJ != null)
            {
                strSql1.Append("iTaxCJ,");
                strSql2.Append("" + model.iTaxCJ + ",");
            }
            if (model.iMoneyFL != null)
            {
                strSql1.Append("iMoneyFL,");
                strSql2.Append("" + model.iMoneyFL + ",");
            }
            if (model.createUid != null)
            {
                strSql1.Append("createUid,");
                strSql2.Append("'" + model.createUid + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("'" + model.dtmCreate + "',");
            }
            if (model.auditUid != null)
            {
                strSql1.Append("auditUid,");
                strSql2.Append("'" + model.auditUid + "',");
            }
            if (model.dtmAudit != null)
            {
                strSql1.Append("dtmAudit,");
                strSql2.Append("'" + model.dtmAudit + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.DLS != null)
            {
                strSql1.Append("DLS,");
                strSql2.Append("'" + model.DLS + "',");
            }
            if (model.DLSName != null)
            {
                strSql1.Append("DLSName,");
                strSql2.Append("'" + model.DLSName + "',");
            }
            if (model.sGUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.sGUID + "',");
            }
            if (model.bRed != null)
            {
                strSql1.Append("bRed,");
                if (Convert.ToBoolean(model.bRed))
                {
                    strSql2.Append("1,");
                }
                else
                {
                    strSql2.Append("0,");
                }
            }
            strSql.Append("insert into _高开返利单_SZ(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _高开返利单_SZ ");
            strSql.Append(" where cCode='" + cCode + "'");
            return strSql.ToString();
        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

