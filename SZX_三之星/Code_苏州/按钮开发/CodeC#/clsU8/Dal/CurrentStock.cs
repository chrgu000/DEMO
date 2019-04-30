using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.clsU8.DAL
{
    /// <summary>
    /// 数据访问类:CurrentStock
    /// </summary>
    public partial class CurrentStock
    {
        public CurrentStock()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string cWhCode, int ItemId, string cBatch, string cVMIVenCode, int iSoType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CurrentStock");
            strSql.Append(" where cWhCode='" + cWhCode + "' and ItemId=" + ItemId + " and cBatch='" + cBatch + "' and cVMIVenCode='" + cVMIVenCode + "' and iSoType=" + iSoType + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.clsU8.Model.CurrentStock model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
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
            if (model.ItemId != null)
            {
                strSql1.Append("ItemId,");
                strSql2.Append("" + model.ItemId + ",");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
            }
            if (model.cVMIVenCode != null)
            {
                strSql1.Append("cVMIVenCode,");
                strSql2.Append("'" + model.cVMIVenCode + "',");
            }
            if (model.iSoType != null)
            {
                strSql1.Append("iSoType,");
                strSql2.Append("" + model.iSoType + ",");
            }
            if (model.iSodid != null)
            {
                strSql1.Append("iSodid,");
                strSql2.Append("'" + model.iSodid + "',");
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
            if (model.fInQuantity != null)
            {
                strSql1.Append("fInQuantity,");
                strSql2.Append("" + model.fInQuantity + ",");
            }
            if (model.fInNum != null)
            {
                strSql1.Append("fInNum,");
                strSql2.Append("" + model.fInNum + ",");
            }
            if (model.cFree3 != null)
            {
                strSql1.Append("cFree3,");
                strSql2.Append("'" + model.cFree3 + "',");
            }
            if (model.cFree4 != null)
            {
                strSql1.Append("cFree4,");
                strSql2.Append("'" + model.cFree4 + "',");
            }
            if (model.cFree5 != null)
            {
                strSql1.Append("cFree5,");
                strSql2.Append("'" + model.cFree5 + "',");
            }
            if (model.cFree6 != null)
            {
                strSql1.Append("cFree6,");
                strSql2.Append("'" + model.cFree6 + "',");
            }
            if (model.cFree7 != null)
            {
                strSql1.Append("cFree7,");
                strSql2.Append("'" + model.cFree7 + "',");
            }
            if (model.cFree8 != null)
            {
                strSql1.Append("cFree8,");
                strSql2.Append("'" + model.cFree8 + "',");
            }
            if (model.cFree9 != null)
            {
                strSql1.Append("cFree9,");
                strSql2.Append("'" + model.cFree9 + "',");
            }
            if (model.cFree10 != null)
            {
                strSql1.Append("cFree10,");
                strSql2.Append("'" + model.cFree10 + "',");
            }
            if (model.dVDate != null)
            {
                strSql1.Append("dVDate,");
                strSql2.Append("'" + model.dVDate + "',");
            }
            if (model.bStopFlag != null)
            {
                strSql1.Append("bStopFlag,");
                strSql2.Append("" + (model.bStopFlag ? 1 : 0) + ",");
            }
            if (model.fTransInQuantity != null)
            {
                strSql1.Append("fTransInQuantity,");
                strSql2.Append("" + model.fTransInQuantity + ",");
            }
            if (model.dMdate != null)
            {
                strSql1.Append("dMdate,");
                strSql2.Append("'" + model.dMdate + "',");
            }
            if (model.fTransInNum != null)
            {
                strSql1.Append("fTransInNum,");
                strSql2.Append("" + model.fTransInNum + ",");
            }
            if (model.fTransOutQuantity != null)
            {
                strSql1.Append("fTransOutQuantity,");
                strSql2.Append("" + model.fTransOutQuantity + ",");
            }
            if (model.fTransOutNum != null)
            {
                strSql1.Append("fTransOutNum,");
                strSql2.Append("" + model.fTransOutNum + ",");
            }
            if (model.fPlanQuantity != null)
            {
                strSql1.Append("fPlanQuantity,");
                strSql2.Append("" + model.fPlanQuantity + ",");
            }
            if (model.fPlanNum != null)
            {
                strSql1.Append("fPlanNum,");
                strSql2.Append("" + model.fPlanNum + ",");
            }
            if (model.fDisableQuantity != null)
            {
                strSql1.Append("fDisableQuantity,");
                strSql2.Append("" + model.fDisableQuantity + ",");
            }
            if (model.fDisableNum != null)
            {
                strSql1.Append("fDisableNum,");
                strSql2.Append("" + model.fDisableNum + ",");
            }
            if (model.fAvaQuantity != null)
            {
                strSql1.Append("fAvaQuantity,");
                strSql2.Append("" + model.fAvaQuantity + ",");
            }
            if (model.fAvaNum != null)
            {
                strSql1.Append("fAvaNum,");
                strSql2.Append("" + model.fAvaNum + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
            }
            if (model.BGSPSTOP != null)
            {
                strSql1.Append("BGSPSTOP,");
                strSql2.Append("" + (model.BGSPSTOP ? 1 : 0) + ",");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.fStopQuantity != null)
            {
                strSql1.Append("fStopQuantity,");
                strSql2.Append("" + model.fStopQuantity + ",");
            }
            if (model.fStopNum != null)
            {
                strSql1.Append("fStopNum,");
                strSql2.Append("" + model.fStopNum + ",");
            }
            if (model.dLastCheckDate != null)
            {
                strSql1.Append("dLastCheckDate,");
                strSql2.Append("'" + model.dLastCheckDate + "',");
            }
            if (model.cCheckState != null)
            {
                strSql1.Append("cCheckState,");
                strSql2.Append("'" + model.cCheckState + "',");
            }
            if (model.dLastYearCheckDate != null)
            {
                strSql1.Append("dLastYearCheckDate,");
                strSql2.Append("'" + model.dLastYearCheckDate + "',");
            }
            if (model.iExpiratDateCalcu != null)
            {
                strSql1.Append("iExpiratDateCalcu,");
                strSql2.Append("" + model.iExpiratDateCalcu + ",");
            }
            if (model.cExpirationdate != null)
            {
                strSql1.Append("cExpirationdate,");
                strSql2.Append("'" + model.cExpirationdate + "',");
            }
            if (model.dExpirationdate != null)
            {
                strSql1.Append("dExpirationdate,");
                strSql2.Append("'" + model.dExpirationdate + "',");
            }
            if (model.ipeqty != null)
            {
                strSql1.Append("ipeqty,");
                strSql2.Append("" + model.ipeqty + ",");
            }
            if (model.ipenum != null)
            {
                strSql1.Append("ipenum,");
                strSql2.Append("" + model.ipenum + ",");
            }
            strSql.Append("insert into CurrentStock(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
             return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.clsU8.Model.CurrentStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CurrentStock set ");
            if (model.iQuantity != null)
            {
                strSql.Append("iQuantity=" + model.iQuantity + ",");
            }
            else
            {
                strSql.Append("iQuantity= null ,");
            }
            if (model.iNum != null)
            {
                strSql.Append("iNum=" + model.iNum + ",");
            }
            else
            {
                strSql.Append("iNum= null ,");
            }
            if (model.fOutQuantity != null)
            {
                strSql.Append("fOutQuantity=" + model.fOutQuantity + ",");
            }
            else
            {
                strSql.Append("fOutQuantity= null ,");
            }
            if (model.fOutNum != null)
            {
                strSql.Append("fOutNum=" + model.fOutNum + ",");
            }
            else
            {
                strSql.Append("fOutNum= null ,");
            }
            if (model.fInQuantity != null)
            {
                strSql.Append("fInQuantity=" + model.fInQuantity + ",");
            }
            else
            {
                strSql.Append("fInQuantity= null ,");
            }
            if (model.fInNum != null)
            {
                strSql.Append("fInNum=" + model.fInNum + ",");
            }
            else
            {
                strSql.Append("fInNum= null ,");
            }
            if (model.dVDate != null)
            {
                strSql.Append("dVDate='" + model.dVDate + "',");
            }
            else
            {
                strSql.Append("dVDate= null ,");
            }
            if (model.bStopFlag != null)
            {
                strSql.Append("bStopFlag=" + (model.bStopFlag ? 1 : 0) + ",");
            }
            if (model.fTransInQuantity != null)
            {
                strSql.Append("fTransInQuantity=" + model.fTransInQuantity + ",");
            }
            else
            {
                strSql.Append("fTransInQuantity= null ,");
            }
            if (model.dMdate != null)
            {
                strSql.Append("dMdate='" + model.dMdate + "',");
            }
            else
            {
                strSql.Append("dMdate= null ,");
            }
            if (model.fTransInNum != null)
            {
                strSql.Append("fTransInNum=" + model.fTransInNum + ",");
            }
            else
            {
                strSql.Append("fTransInNum= null ,");
            }
            if (model.fTransOutQuantity != null)
            {
                strSql.Append("fTransOutQuantity=" + model.fTransOutQuantity + ",");
            }
            else
            {
                strSql.Append("fTransOutQuantity= null ,");
            }
            if (model.fTransOutNum != null)
            {
                strSql.Append("fTransOutNum=" + model.fTransOutNum + ",");
            }
            else
            {
                strSql.Append("fTransOutNum= null ,");
            }
            if (model.fPlanQuantity != null)
            {
                strSql.Append("fPlanQuantity=" + model.fPlanQuantity + ",");
            }
            else
            {
                strSql.Append("fPlanQuantity= null ,");
            }
            if (model.fPlanNum != null)
            {
                strSql.Append("fPlanNum=" + model.fPlanNum + ",");
            }
            else
            {
                strSql.Append("fPlanNum= null ,");
            }
            if (model.fDisableQuantity != null)
            {
                strSql.Append("fDisableQuantity=" + model.fDisableQuantity + ",");
            }
            else
            {
                strSql.Append("fDisableQuantity= null ,");
            }
            if (model.fDisableNum != null)
            {
                strSql.Append("fDisableNum=" + model.fDisableNum + ",");
            }
            else
            {
                strSql.Append("fDisableNum= null ,");
            }
            if (model.fAvaQuantity != null)
            {
                strSql.Append("fAvaQuantity=" + model.fAvaQuantity + ",");
            }
            else
            {
                strSql.Append("fAvaQuantity= null ,");
            }
            if (model.fAvaNum != null)
            {
                strSql.Append("fAvaNum=" + model.fAvaNum + ",");
            }
            else
            {
                strSql.Append("fAvaNum= null ,");
            }
            if (model.iMassDate != null)
            {
                strSql.Append("iMassDate=" + model.iMassDate + ",");
            }
            else
            {
                strSql.Append("iMassDate= null ,");
            }
            if (model.BGSPSTOP != null)
            {
                strSql.Append("BGSPSTOP=" + (model.BGSPSTOP ? 1 : 0) + ",");
            }
            if (model.cMassUnit != null)
            {
                strSql.Append("cMassUnit=" + model.cMassUnit + ",");
            }
            else
            {
                strSql.Append("cMassUnit= null ,");
            }
            if (model.fStopQuantity != null)
            {
                strSql.Append("fStopQuantity=" + model.fStopQuantity + ",");
            }
            else
            {
                strSql.Append("fStopQuantity= null ,");
            }
            if (model.fStopNum != null)
            {
                strSql.Append("fStopNum=" + model.fStopNum + ",");
            }
            else
            {
                strSql.Append("fStopNum= null ,");
            }
            if (model.dLastCheckDate != null)
            {
                strSql.Append("dLastCheckDate='" + model.dLastCheckDate + "',");
            }
            else
            {
                strSql.Append("dLastCheckDate= null ,");
            }
            if (model.cCheckState != null)
            {
                strSql.Append("cCheckState='" + model.cCheckState + "',");
            }
            if (model.dLastYearCheckDate != null)
            {
                strSql.Append("dLastYearCheckDate='" + model.dLastYearCheckDate + "',");
            }
            else
            {
                strSql.Append("dLastYearCheckDate= null ,");
            }
            if (model.iExpiratDateCalcu != null)
            {
                strSql.Append("iExpiratDateCalcu=" + model.iExpiratDateCalcu + ",");
            }
            else
            {
                strSql.Append("iExpiratDateCalcu= null ,");
            }
            if (model.cExpirationdate != null)
            {
                strSql.Append("cExpirationdate='" + model.cExpirationdate + "',");
            }
            else
            {
                strSql.Append("cExpirationdate= null ,");
            }
            if (model.dExpirationdate != null)
            {
                strSql.Append("dExpirationdate='" + model.dExpirationdate + "',");
            }
            else
            {
                strSql.Append("dExpirationdate= null ,");
            }
            if (model.ipeqty != null)
            {
                strSql.Append("ipeqty=" + model.ipeqty + ",");
            }
            if (model.ipenum != null)
            {
                strSql.Append("ipenum=" + model.ipenum + ",");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where AutoID=" + model.AutoID + "");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

