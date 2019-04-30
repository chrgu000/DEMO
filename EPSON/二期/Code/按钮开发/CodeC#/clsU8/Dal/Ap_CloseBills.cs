using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:Ap_CloseBills
    /// </summary>
    public partial class Ap_CloseBills
    {
        public Ap_CloseBills()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.Ap_CloseBills model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iID != null)
            {
                strSql1.Append("iID,");
                strSql2.Append("" + model.iID + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.iType != null)
            {
                strSql1.Append("iType,");
                strSql2.Append("" + model.iType + ",");
            }
            if (model.bPrePay != null)
            {
                strSql1.Append("bPrePay,");
                strSql2.Append("" + (model.bPrePay ? 1 : 0) + ",");
            }
            if (model.cCusVen != null)
            {
                strSql1.Append("cCusVen,");
                strSql2.Append("'" + model.cCusVen + "',");
            }
            if (model.iAmt_f != null)
            {
                strSql1.Append("iAmt_f,");
                strSql2.Append("" + model.iAmt_f + ",");
            }
            if (model.iAmt != null)
            {
                strSql1.Append("iAmt,");
                strSql2.Append("" + model.iAmt + ",");
            }
            if (model.iRAmt_f != null)
            {
                strSql1.Append("iRAmt_f,");
                strSql2.Append("" + model.iRAmt_f + ",");
            }
            if (model.iRAmt != null)
            {
                strSql1.Append("iRAmt,");
                strSql2.Append("" + model.iRAmt + ",");
            }
            if (model.cKm != null)
            {
                strSql1.Append("cKm,");
                strSql2.Append("'" + model.cKm + "',");
            }
            if (model.cXmClass != null)
            {
                strSql1.Append("cXmClass,");
                strSql2.Append("'" + model.cXmClass + "',");
            }
            if (model.cXm != null)
            {
                strSql1.Append("cXm,");
                strSql2.Append("'" + model.cXm + "',");
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
            if (model.cOrderID != null)
            {
                strSql1.Append("cOrderID,");
                strSql2.Append("'" + model.cOrderID + "',");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
            }
            if (model.cConType != null)
            {
                strSql1.Append("cConType,");
                strSql2.Append("'" + model.cConType + "',");
            }
            if (model.cConID != null)
            {
                strSql1.Append("cConID,");
                strSql2.Append("'" + model.cConID + "',");
            }
            if (model.iAmt_s != null)
            {
                strSql1.Append("iAmt_s,");
                strSql2.Append("" + model.iAmt_s + ",");
            }
            if (model.iRAmt_s != null)
            {
                strSql1.Append("iRAmt_s,");
                strSql2.Append("" + model.iRAmt_s + ",");
            }
            if (model.iOrderType != null)
            {
                strSql1.Append("iOrderType,");
                strSql2.Append("" + model.iOrderType + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("'" + model.cDLCode + "',");
            }
            if (model.ccItemCode != null)
            {
                strSql1.Append("ccItemCode,");
                strSql2.Append("'" + model.ccItemCode + "',");
            }
            if (model.RegisterFlag != null)
            {
                strSql1.Append("RegisterFlag,");
                strSql2.Append("" + model.RegisterFlag + ",");
            }
            if (model.cDefine22 != null)
            {
                strSql1.Append("cDefine22,");
                strSql2.Append("'" + model.cDefine22 + "',");
            }
            if (model.cDefine23 != null)
            {
                strSql1.Append("cDefine23,");
                strSql2.Append("'" + model.cDefine23 + "',");
            }
            if (model.cDefine24 != null)
            {
                strSql1.Append("cDefine24,");
                strSql2.Append("'" + model.cDefine24 + "',");
            }
            if (model.cDefine25 != null)
            {
                strSql1.Append("cDefine25,");
                strSql2.Append("'" + model.cDefine25 + "',");
            }
            if (model.cDefine26 != null)
            {
                strSql1.Append("cDefine26,");
                strSql2.Append("" + model.cDefine26 + ",");
            }
            if (model.cDefine27 != null)
            {
                strSql1.Append("cDefine27,");
                strSql2.Append("" + model.cDefine27 + ",");
            }
            if (model.cDefine28 != null)
            {
                strSql1.Append("cDefine28,");
                strSql2.Append("'" + model.cDefine28 + "',");
            }
            if (model.cDefine29 != null)
            {
                strSql1.Append("cDefine29,");
                strSql2.Append("'" + model.cDefine29 + "',");
            }
            if (model.cDefine30 != null)
            {
                strSql1.Append("cDefine30,");
                strSql2.Append("'" + model.cDefine30 + "',");
            }
            if (model.cDefine31 != null)
            {
                strSql1.Append("cDefine31,");
                strSql2.Append("'" + model.cDefine31 + "',");
            }
            if (model.cDefine32 != null)
            {
                strSql1.Append("cDefine32,");
                strSql2.Append("'" + model.cDefine32 + "',");
            }
            if (model.cDefine33 != null)
            {
                strSql1.Append("cDefine33,");
                strSql2.Append("'" + model.cDefine33 + "',");
            }
            if (model.cDefine34 != null)
            {
                strSql1.Append("cDefine34,");
                strSql2.Append("" + model.cDefine34 + ",");
            }
            if (model.cDefine35 != null)
            {
                strSql1.Append("cDefine35,");
                strSql2.Append("" + model.cDefine35 + ",");
            }
            if (model.cDefine36 != null)
            {
                strSql1.Append("cDefine36,");
                strSql2.Append("'" + model.cDefine36 + "',");
            }
            if (model.cDefine37 != null)
            {
                strSql1.Append("cDefine37,");
                strSql2.Append("'" + model.cDefine37 + "',");
            }
            if (model.cStageCode != null)
            {
                strSql1.Append("cStageCode,");
                strSql2.Append("'" + model.cStageCode + "',");
            }
            if (model.cCoVouchID != null)
            {
                strSql1.Append("cCoVouchID,");
                strSql2.Append("'" + model.cCoVouchID + "',");
            }
            if (model.cExecID != null)
            {
                strSql1.Append("cExecID,");
                strSql2.Append("'" + model.cExecID + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.iSrcClosesID != null)
            {
                strSql1.Append("iSrcClosesID,");
                strSql2.Append("" + model.iSrcClosesID + ",");
            }
            if (model.ifaresettled_f != null)
            {
                strSql1.Append("ifaresettled_f,");
                strSql2.Append("" + model.ifaresettled_f + ",");
            }
            if (model.cEBOrderCode != null)
            {
                strSql1.Append("cEBOrderCode,");
                strSql2.Append("'" + model.cEBOrderCode + "',");
            }
            strSql.Append("insert into Ap_CloseBills(");
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

