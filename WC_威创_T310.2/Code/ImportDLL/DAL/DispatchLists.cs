using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ImportDLL.DAL
{
    /// <summary>
    /// 数据访问类:DispatchLists
    /// </summary>
    public partial class DispatchLists
    {
        public DispatchLists()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ImportDLL.Model.DispatchLists model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.DLID != null)
            {
                strSql1.Append("DLID,");
                strSql2.Append("" + model.DLID + ",");
            }
            if (model.iCorID != null)
            {
                strSql1.Append("iCorID,");
                strSql2.Append("" + model.iCorID + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.iQuantity != null)
            {
                strSql1.Append("iQuantity,");
                strSql2.Append("" + model.iQuantity + ",");
            }
            if (model.iNum != null)
            {
                strSql1.Append("iNum,");
                strSql2.Append("" + model.iNum + ",");
            }
            if (model.iQuotedPrice != null)
            {
                strSql1.Append("iQuotedPrice,");
                strSql2.Append("" + model.iQuotedPrice + ",");
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
            if (model.iSum != null)
            {
                strSql1.Append("iSum,");
                strSql2.Append("" + model.iSum + ",");
            }
            if (model.iDisCount != null)
            {
                strSql1.Append("iDisCount,");
                strSql2.Append("" + model.iDisCount + ",");
            }
            if (model.iNatUnitPrice != null)
            {
                strSql1.Append("iNatUnitPrice,");
                strSql2.Append("" + model.iNatUnitPrice + ",");
            }
            if (model.iNatMoney != null)
            {
                strSql1.Append("iNatMoney,");
                strSql2.Append("" + model.iNatMoney + ",");
            }
            if (model.iNatTax != null)
            {
                strSql1.Append("iNatTax,");
                strSql2.Append("" + model.iNatTax + ",");
            }
            if (model.iNatSum != null)
            {
                strSql1.Append("iNatSum,");
                strSql2.Append("" + model.iNatSum + ",");
            }
            if (model.iNatDisCount != null)
            {
                strSql1.Append("iNatDisCount,");
                strSql2.Append("" + model.iNatDisCount + ",");
            }
            if (model.iSettleNum != null)
            {
                strSql1.Append("iSettleNum,");
                strSql2.Append("" + model.iSettleNum + ",");
            }
            if (model.iSettleQuantity != null)
            {
                strSql1.Append("iSettleQuantity,");
                strSql2.Append("" + model.iSettleQuantity + ",");
            }
            if (model.iBatch != null)
            {
                strSql1.Append("iBatch,");
                strSql2.Append("" + model.iBatch + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.bSettleAll != null)
            {
                strSql1.Append("bSettleAll,");
                strSql2.Append("" + (model.bSettleAll ? 1 : 0) + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cFree1 != null)
            {
                strSql1.Append("cFree1,");
                strSql2.Append("'" + model.cFree1 + "',");
            }
            if (model.cFree2 != null)
            {
                strSql1.Append("cFree2,");
                strSql2.Append("'" + model.cFree2 + "',");
            }
            if (model.RdsID != null)
            {
                strSql1.Append("RdsID,");
                strSql2.Append("" + model.RdsID + ",");
            }
            if (model.iTB != null)
            {
                strSql1.Append("iTB,");
                strSql2.Append("" + model.iTB + ",");
            }
            if (model.dvDate != null)
            {
                strSql1.Append("dvDate,");
                strSql2.Append("'" + model.dvDate + "',");
            }
            if (model.TBQuantity != null)
            {
                strSql1.Append("TBQuantity,");
                strSql2.Append("" + model.TBQuantity + ",");
            }
            if (model.TBNum != null)
            {
                strSql1.Append("TBNum,");
                strSql2.Append("" + model.TBNum + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.iDLsID != null)
            {
                strSql1.Append("iDLsID,");
                strSql2.Append("" + model.iDLsID + ",");
            }
            if (model.KL != null)
            {
                strSql1.Append("KL,");
                strSql2.Append("" + model.KL + ",");
            }
            if (model.KL2 != null)
            {
                strSql1.Append("KL2,");
                strSql2.Append("" + model.KL2 + ",");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
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
            if (model.fOutQuantity != null)
            {
                strSql1.Append("fOutQuantity,");
                strSql2.Append("" + model.fOutQuantity + ",");
            }
            if (model.fOutNum != null)
            {
                strSql1.Append("fOutNum,");
                strSql2.Append("" + model.fOutNum + ",");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.cItem_class != null)
            {
                strSql1.Append("cItem_class,");
                strSql2.Append("'" + model.cItem_class + "',");
            }
            if (model.fSaleCost != null)
            {
                strSql1.Append("fSaleCost,");
                strSql2.Append("" + model.fSaleCost + ",");
            }
            if (model.fSalePrice != null)
            {
                strSql1.Append("fSalePrice,");
                strSql2.Append("" + model.fSalePrice + ",");
            }
            if (model.cVenAbbName != null)
            {
                strSql1.Append("cVenAbbName,");
                strSql2.Append("'" + model.cVenAbbName + "',");
            }
            if (model.cItemName != null)
            {
                strSql1.Append("cItemName,");
                strSql2.Append("'" + model.cItemName + "',");
            }
            if (model.cItem_CName != null)
            {
                strSql1.Append("cItem_CName,");
                strSql2.Append("'" + model.cItem_CName + "',");
            }
            if (model.iInvExchRate != null)
            {
                strSql1.Append("iInvExchRate,");
                strSql2.Append("" + model.iInvExchRate + ",");
            }
            strSql.Append("insert into DispatchLists(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

