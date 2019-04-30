using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using TH.WebService.BaseClass;


namespace TH.DAL
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
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.CurrentStock model)
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
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
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
            strSql.Append("insert into @u8.CurrentStock(");
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
        public string Update(TH.Model.CurrentStock model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.CurrentStock set ");
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
            else
            {
                strSql.Append("bStopFlag= null ,");
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
            else
            {
                strSql.Append("BGSPSTOP= null ,");
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

