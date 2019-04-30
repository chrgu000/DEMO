using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_DispatchLists_SaleBillVouchs
    /// </summary>
    public partial class _DispatchLists_SaleBillVouchs
    {
        public _DispatchLists_SaleBillVouchs()
        { }
        #region  Method


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DispatchLists_SaleBillVouchs model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.GUID + "',");
            }
            if (model.DLsID != null)
            {
                strSql1.Append("DLsID,");
                strSql2.Append("" + model.DLsID + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cexch_name != null)
            {
                strSql1.Append("cexch_name,");
                strSql2.Append("'" + model.cexch_name + "',");
            }
            if (model.SaleBillsID != null)
            {
                strSql1.Append("SaleBillsID,");
                strSql2.Append("" + model.SaleBillsID + ",");
            }
            if (model.Item != null)
            {
                strSql1.Append("Item,");
                strSql2.Append("'" + model.Item + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.DLsQty != null)
            {
                strSql1.Append("DLsQty,");
                strSql2.Append("" + model.DLsQty + ",");
            }
            if (model.SaleBillsQty != null)
            {
                strSql1.Append("SaleBillsQty,");
                strSql2.Append("" + model.SaleBillsQty + ",");
            }
            if (model.DLCode != null)
            {
                strSql1.Append("DLCode,");
                strSql2.Append("'" + model.DLCode + "',");
            }
            if (model.SaleBillCode != null)
            {
                strSql1.Append("SaleBillCode,");
                strSql2.Append("'" + model.SaleBillCode + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.dtmLogin != null)
            {
                strSql1.Append("dtmLogin,");
                strSql2.Append("'" + model.dtmLogin + "',");
            }
            if (model.iUnitPrice != null)
            {
                strSql1.Append("iUnitPrice,");
                strSql2.Append("" + model.iUnitPrice + ",");
            }
            if (model.iTaxUnitPrice != null)
            {
                strSql1.Append("iTaxUnitPrice,");
                strSql2.Append("" + model.iTaxUnitPrice + ",");
            }
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.iMoney != null)
            {
                strSql1.Append("iMoney,");
                strSql2.Append("" + model.iMoney + ",");
            }
            if (model.iTax != null)
            {
                strSql1.Append("iTax,");
                strSql2.Append("" + model.iTax + ",");
            }
            if (model.iNatSum != null)
            {
                strSql1.Append("iNatSum,");
                strSql2.Append("" + model.iNatSum + ",");
            }
            if (model.iNatMoney != null)
            {
                strSql1.Append("iNatMoney,");
                strSql2.Append("" + model.iNatMoney + ",");
            }
            if (model.iNatUnitPrice != null)
            {
                strSql1.Append("iNatUnitPrice,");
                strSql2.Append("" + model.iNatUnitPrice + ",");
            }
            if (model.iNatTax != null)
            {
                strSql1.Append("iNatTax,");
                strSql2.Append("" + model.iNatTax + ",");
            }
            strSql.Append("insert into _DispatchLists_SaleBillVouchs(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string sGuid,DateTime dtmLogin,string sUid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _DispatchLists_SaleBillVouchs ");
            strSql.Append(" where GUID = '" + sGuid + "' and dtmLogin = '" + dtmLogin.ToString("yyyy-MM-dd") + "' and CreateUid = '" + sUid + "'");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

