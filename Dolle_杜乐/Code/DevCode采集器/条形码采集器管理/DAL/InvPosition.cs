using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BarCode.DAL
{
    /// <summary>
    /// 数据访问类:InvPosition
    /// </summary>
    public partial class InvPosition
    {
        public InvPosition()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(BarCode.Model.InvPosition model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.RdsID != null)
            {
                strSql1.Append("RdsID,");
                strSql2.Append("" + model.RdsID + ",");
            }
            if (model.RdID != null)
            {
                strSql1.Append("RdID,");
                strSql2.Append("" + model.RdID + ",");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.cPosCode != null)
            {
                strSql1.Append("cPosCode,");
                strSql2.Append("'" + model.cPosCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cBatch != null)
            {
                strSql1.Append("cBatch,");
                strSql2.Append("'" + model.cBatch + "',");
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
            if (model.dVDate != null)
            {
                strSql1.Append("dVDate,");
                strSql2.Append("'" + model.dVDate + "',");
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
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.cHandler != null)
            {
                strSql1.Append("cHandler,");
                strSql2.Append("'" + model.cHandler + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.bRdFlag != null)
            {
                strSql1.Append("bRdFlag,");
                strSql2.Append("" + model.bRdFlag + ",");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
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
            if (model.cAssUnit != null)
            {
                strSql1.Append("cAssUnit,");
                strSql2.Append("'" + model.cAssUnit + "',");
            }
            if (model.cBVencode != null)
            {
                strSql1.Append("cBVencode,");
                strSql2.Append("'" + model.cBVencode + "',");
            }
            if (model.iTrackId != null)
            {
                strSql1.Append("iTrackId,");
                strSql2.Append("" + model.iTrackId + ",");
            }
            if (model.dMadeDate != null)
            {
                strSql1.Append("dMadeDate,");
                strSql2.Append("'" + model.dMadeDate + "',");
            }
            if (model.iMassDate != null)
            {
                strSql1.Append("iMassDate,");
                strSql2.Append("" + model.iMassDate + ",");
            }
            if (model.cMassUnit != null)
            {
                strSql1.Append("cMassUnit,");
                strSql2.Append("" + model.cMassUnit + ",");
            }
            if (model.cvmivencode != null)
            {
                strSql1.Append("cvmivencode,");
                strSql2.Append("'" + model.cvmivencode + "',");
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
            if (model.cvouchtype != null)
            {
                strSql1.Append("cvouchtype,");
                strSql2.Append("'" + model.cvouchtype + "',");
            }
            if (model.cInVouchType != null)
            {
                strSql1.Append("cInVouchType,");
                strSql2.Append("'" + model.cInVouchType + "',");
            }
            if (model.cVerifier != null)
            {
                strSql1.Append("cVerifier,");
                strSql2.Append("'" + model.cVerifier + "',");
            }
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.dVouchDate != null)
            {
                strSql1.Append("dVouchDate,");
                strSql2.Append("'" + model.dVouchDate + "',");
            }
            strSql.Append("insert into @u8.InvPosition(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1, 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(BarCode.Model.InvPosition model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.InvPosition set ");
            if (model.dVDate != null)
            {
                strSql.Append("dVDate='" + model.dVDate + "',");
            }
            else
            {
                strSql.Append("dVDate= null ,");
            }
            if (model.iNum != null)
            {
                strSql.Append("iNum=" + model.iNum + ",");
            }
            else
            {
                strSql.Append("iNum= null ,");
            }
            if (model.cMemo != null)
            {
                strSql.Append("cMemo='" + model.cMemo + "',");
            }
            else
            {
                strSql.Append("cMemo= null ,");
            }
            if (model.cHandler != null)
            {
                strSql.Append("cHandler='" + model.cHandler + "',");
            }
            else
            {
                strSql.Append("cHandler= null ,");
            }
            if (model.dDate != null)
            {
                strSql.Append("dDate='" + model.dDate + "',");
            }
            else
            {
                strSql.Append("dDate= null ,");
            }
            if (model.bRdFlag != null)
            {
                strSql.Append("bRdFlag=" + model.bRdFlag + ",");
            }
            if (model.cAssUnit != null)
            {
                strSql.Append("cAssUnit='" + model.cAssUnit + "',");
            }
            else
            {
                strSql.Append("cAssUnit= null ,");
            }
            if (model.cBVencode != null)
            {
                strSql.Append("cBVencode='" + model.cBVencode + "',");
            }
            else
            {
                strSql.Append("cBVencode= null ,");
            }
            if (model.iTrackId != null)
            {
                strSql.Append("iTrackId=" + model.iTrackId + ",");
            }
            else
            {
                strSql.Append("iTrackId= null ,");
            }
            if (model.dMadeDate != null)
            {
                strSql.Append("dMadeDate='" + model.dMadeDate + "',");
            }
            else
            {
                strSql.Append("dMadeDate= null ,");
            }
            if (model.iMassDate != null)
            {
                strSql.Append("iMassDate=" + model.iMassDate + ",");
            }
            else
            {
                strSql.Append("iMassDate= null ,");
            }
            if (model.cMassUnit != null)
            {
                strSql.Append("cMassUnit=" + model.cMassUnit + ",");
            }
            else
            {
                strSql.Append("cMassUnit= null ,");
            }
            if (model.cvmivencode != null)
            {
                strSql.Append("cvmivencode='" + model.cvmivencode + "',");
            }
            else
            {
                strSql.Append("cvmivencode= null ,");
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
            if (model.cInVouchType != null)
            {
                strSql.Append("cInVouchType='" + model.cInVouchType + "',");
            }
            else
            {
                strSql.Append("cInVouchType= null ,");
            }
            if (model.cVerifier != null)
            {
                strSql.Append("cVerifier='" + model.cVerifier + "',");
            }
            else
            {
                strSql.Append("cVerifier= null ,");
            }
            if (model.dVeriDate != null)
            {
                strSql.Append("dVeriDate='" + model.dVeriDate + "',");
            }
            else
            {
                strSql.Append("dVeriDate= null ,");
            }
            if (model.dVouchDate != null)
            {
                strSql.Append("dVouchDate='" + model.dVouchDate + "',");
            }
            else
            {
                strSql.Append("dVouchDate= null ,");
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


