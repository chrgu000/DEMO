using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ImportDLL.DAL
{
    /// <summary>
    /// 数据访问类:Inventory
    /// </summary>
    public partial class Inventory
    {
        public Inventory()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ImportDLL.Model.Inventory model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
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
            if (model.cInvCCode != null)
            {
                strSql1.Append("cInvCCode,");
                strSql2.Append("'" + model.cInvCCode + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cInvM_Unit != null)
            {
                strSql1.Append("cInvM_Unit,");
                strSql2.Append("'" + model.cInvM_Unit + "',");
            }
            if (model.cInvA_Unit != null)
            {
                strSql1.Append("cInvA_Unit,");
                strSql2.Append("'" + model.cInvA_Unit + "',");
            }
            if (model.cReplaceItem != null)
            {
                strSql1.Append("cReplaceItem,");
                strSql2.Append("'" + model.cReplaceItem + "',");
            }
            if (model.cPosition != null)
            {
                strSql1.Append("cPosition,");
                strSql2.Append("'" + model.cPosition + "',");
            }
            if (model.bSale != null)
            {
                strSql1.Append("bSale,");
                strSql2.Append("" + (model.bSale ? 1 : 0) + ",");
            }
            if (model.bPurchase != null)
            {
                strSql1.Append("bPurchase,");
                strSql2.Append("" + (model.bPurchase ? 1 : 0) + ",");
            }
            if (model.bSelf != null)
            {
                strSql1.Append("bSelf,");
                strSql2.Append("" + (model.bSelf ? 1 : 0) + ",");
            }
            if (model.bComsume != null)
            {
                strSql1.Append("bComsume,");
                strSql2.Append("" + (model.bComsume ? 1 : 0) + ",");
            }
            if (model.bProducing != null)
            {
                strSql1.Append("bProducing,");
                strSql2.Append("" + (model.bProducing ? 1 : 0) + ",");
            }
            if (model.bService != null)
            {
                strSql1.Append("bService,");
                strSql2.Append("" + (model.bService ? 1 : 0) + ",");
            }
            if (model.bAccessary != null)
            {
                strSql1.Append("bAccessary,");
                strSql2.Append("" + (model.bAccessary ? 1 : 0) + ",");
            }
            if (model.iInvExchRate != null)
            {
                strSql1.Append("iInvExchRate,");
                strSql2.Append("" + model.iInvExchRate + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.iInvWeight != null)
            {
                strSql1.Append("iInvWeight,");
                strSql2.Append("" + model.iInvWeight + ",");
            }
            if (model.iVolume != null)
            {
                strSql1.Append("iVolume,");
                strSql2.Append("" + model.iVolume + ",");
            }
            if (model.iInvRCost != null)
            {
                strSql1.Append("iInvRCost,");
                strSql2.Append("" + model.iInvRCost + ",");
            }
            if (model.iInvSPrice != null)
            {
                strSql1.Append("iInvSPrice,");
                strSql2.Append("" + model.iInvSPrice + ",");
            }
            if (model.iInvSCost != null)
            {
                strSql1.Append("iInvSCost,");
                strSql2.Append("" + model.iInvSCost + ",");
            }
            if (model.iInvLSCost != null)
            {
                strSql1.Append("iInvLSCost,");
                strSql2.Append("" + model.iInvLSCost + ",");
            }
            if (model.iInvNCost != null)
            {
                strSql1.Append("iInvNCost,");
                strSql2.Append("" + model.iInvNCost + ",");
            }
            if (model.iInvAdvance != null)
            {
                strSql1.Append("iInvAdvance,");
                strSql2.Append("" + model.iInvAdvance + ",");
            }
            if (model.iInvBatch != null)
            {
                strSql1.Append("iInvBatch,");
                strSql2.Append("" + model.iInvBatch + ",");
            }
            if (model.iSafeNum != null)
            {
                strSql1.Append("iSafeNum,");
                strSql2.Append("" + model.iSafeNum + ",");
            }
            if (model.iTopSum != null)
            {
                strSql1.Append("iTopSum,");
                strSql2.Append("" + model.iTopSum + ",");
            }
            if (model.iLowSum != null)
            {
                strSql1.Append("iLowSum,");
                strSql2.Append("" + model.iLowSum + ",");
            }
            if (model.iOverStock != null)
            {
                strSql1.Append("iOverStock,");
                strSql2.Append("" + model.iOverStock + ",");
            }
            if (model.cInvABC != null)
            {
                strSql1.Append("cInvABC,");
                strSql2.Append("'" + model.cInvABC + "',");
            }
            if (model.bInvQuality != null)
            {
                strSql1.Append("bInvQuality,");
                strSql2.Append("" + (model.bInvQuality ? 1 : 0) + ",");
            }
            if (model.bInvBatch != null)
            {
                strSql1.Append("bInvBatch,");
                strSql2.Append("" + (model.bInvBatch ? 1 : 0) + ",");
            }
            if (model.bInvEntrust != null)
            {
                strSql1.Append("bInvEntrust,");
                strSql2.Append("" + (model.bInvEntrust ? 1 : 0) + ",");
            }
            if (model.bInvOverStock != null)
            {
                strSql1.Append("bInvOverStock,");
                strSql2.Append("" + (model.bInvOverStock ? 1 : 0) + ",");
            }
            if (model.dSDate != null)
            {
                strSql1.Append("dSDate,");
                strSql2.Append("'" + model.dSDate + "',");
            }
            if (model.dEDate != null)
            {
                strSql1.Append("dEDate,");
                strSql2.Append("'" + model.dEDate + "',");
            }
            if (model.bFree1 != null)
            {
                strSql1.Append("bFree1,");
                strSql2.Append("" + (model.bFree1 ? 1 : 0) + ",");
            }
            if (model.bFree2 != null)
            {
                strSql1.Append("bFree2,");
                strSql2.Append("" + (model.bFree2 ? 1 : 0) + ",");
            }
            if (model.cInvDefine1 != null)
            {
                strSql1.Append("cInvDefine1,");
                strSql2.Append("'" + model.cInvDefine1 + "',");
            }
            if (model.cInvDefine2 != null)
            {
                strSql1.Append("cInvDefine2,");
                strSql2.Append("'" + model.cInvDefine2 + "',");
            }
            if (model.cInvDefine3 != null)
            {
                strSql1.Append("cInvDefine3,");
                strSql2.Append("'" + model.cInvDefine3 + "',");
            }
            if (model.bInvType != null)
            {
                strSql1.Append("bInvType,");
                strSql2.Append("" + (model.bInvType ? 1 : 0) + ",");
            }
            if (model.iInvMPCost != null)
            {
                strSql1.Append("iInvMPCost,");
                strSql2.Append("" + model.iInvMPCost + ",");
            }
            if (model.cQuality != null)
            {
                strSql1.Append("cQuality,");
                strSql2.Append("'" + model.cQuality + "',");
            }
            if (model.iInvSaleCost != null)
            {
                strSql1.Append("iInvSaleCost,");
                strSql2.Append("" + model.iInvSaleCost + ",");
            }
            if (model.iInvSCost1 != null)
            {
                strSql1.Append("iInvSCost1,");
                strSql2.Append("" + model.iInvSCost1 + ",");
            }
            if (model.iInvSCost2 != null)
            {
                strSql1.Append("iInvSCost2,");
                strSql2.Append("" + model.iInvSCost2 + ",");
            }
            if (model.iInvSCost3 != null)
            {
                strSql1.Append("iInvSCost3,");
                strSql2.Append("" + model.iInvSCost3 + ",");
            }
            if (model.iInvSCost4 != null)
            {
                strSql1.Append("iInvSCost4,");
                strSql2.Append("" + model.iInvSCost4 + ",");
            }
            if (model.iInvSCost5 != null)
            {
                strSql1.Append("iInvSCost5,");
                strSql2.Append("" + model.iInvSCost5 + ",");
            }
            if (model.iInvWSPrice != null)
            {
                strSql1.Append("iInvWSPrice,");
                strSql2.Append("" + model.iInvWSPrice + ",");
            }
            if (model.cInvHelp != null)
            {
                strSql1.Append("cInvHelp,");
                strSql2.Append("'" + model.cInvHelp + "',");
            }
            strSql.Append("insert into Inventory(");
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

