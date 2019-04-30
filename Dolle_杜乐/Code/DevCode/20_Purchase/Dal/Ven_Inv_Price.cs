using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Purchase.DAL
{
    /// <summary>
    /// 数据访问类:Ven_Inv_Price
    /// </summary>
    public partial class Ven_Inv_Price
    {
        public Ven_Inv_Price()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(Purchase.Model.Ven_Inv_Price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from @u8.Ven_Inv_Price");
            strSql.Append(" where cvencode = '" + model.cVenCode + "' and cInvCode = '" + model.cInvCode + "' and isupplytype = " + model.iSupplyType.ToString() + " and ilowerlimit = " + model.iLowerLimit.ToString());
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Purchase.Model.Ven_Inv_Price model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.dEnableDate != null)
            {
                strSql1.Append("dEnableDate,");
                strSql2.Append("'" + model.dEnableDate + "',");
            }
            if (model.dDisableDate != null)
            {
                strSql1.Append("dDisableDate,");
                strSql2.Append("'" + model.dDisableDate + "',");
            }
            if (model.cExch_Name != null)
            {
                strSql1.Append("cExch_Name,");
                strSql2.Append("'" + model.cExch_Name + "',");
            }
            if (model.bPromotion != null)
            {
                strSql1.Append("bPromotion,");
                strSql2.Append("" + model.bPromotion + ",");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.iSupplyType != null)
            {
                strSql1.Append("iSupplyType,");
                strSql2.Append("" + model.iSupplyType + ",");
            }
            if (model.btaxcost != null)
            {
                strSql1.Append("btaxcost,");
                strSql2.Append("" + model.btaxcost + ",");
            }
            if (model.cTermCode != null)
            {
                strSql1.Append("cTermCode,");
                strSql2.Append("'" + model.cTermCode + "',");
            }
            if (model.iLowerLimit != null)
            {
                strSql1.Append("iLowerLimit,");
                strSql2.Append("" + model.iLowerLimit + ",");
            }
            if (model.iUpperLimit != null)
            {
                strSql1.Append("iUpperLimit,");
                strSql2.Append("" + model.iUpperLimit + ",");
            }
            if (model.iUnitPrice != null)
            {
                strSql1.Append("iUnitPrice,");
                strSql2.Append("" + model.iUnitPrice + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql1.Append("iTaxRate,");
                strSql2.Append("" + model.iTaxRate + ",");
            }
            if (model.iTaxUnitPrice != null)
            {
                strSql1.Append("iTaxUnitPrice,");
                strSql2.Append("" + model.iTaxUnitPrice + ",");
            }
            if (model.ipriceautoid != null)
            {
                strSql1.Append("ipriceautoid,");
                strSql2.Append("" + model.ipriceautoid + ",");
            }
            if (model.cfree1 != null)
            {
                strSql1.Append("cfree1,");
                strSql2.Append("'" + model.cfree1 + "',");
            }
            if (model.cfree2 != null)
            {
                strSql1.Append("cfree2,");
                strSql2.Append("'" + model.cfree2 + "',");
            }
            if (model.cfree3 != null)
            {
                strSql1.Append("cfree3,");
                strSql2.Append("'" + model.cfree3 + "',");
            }
            if (model.cfree4 != null)
            {
                strSql1.Append("cfree4,");
                strSql2.Append("'" + model.cfree4 + "',");
            }
            if (model.cfree5 != null)
            {
                strSql1.Append("cfree5,");
                strSql2.Append("'" + model.cfree5 + "',");
            }
            if (model.cfree6 != null)
            {
                strSql1.Append("cfree6,");
                strSql2.Append("'" + model.cfree6 + "',");
            }
            if (model.cfree7 != null)
            {
                strSql1.Append("cfree7,");
                strSql2.Append("'" + model.cfree7 + "',");
            }
            if (model.cfree8 != null)
            {
                strSql1.Append("cfree8,");
                strSql2.Append("'" + model.cfree8 + "',");
            }
            if (model.cfree9 != null)
            {
                strSql1.Append("cfree9,");
                strSql2.Append("'" + model.cfree9 + "',");
            }
            if (model.cfree10 != null)
            {
                strSql1.Append("cfree10,");
                strSql2.Append("'" + model.cfree10 + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cSourceCode != null)
            {
                strSql1.Append("cSourceCode,");
                strSql2.Append("'" + model.cSourceCode + "',");
            }
            if (model.cSourceAutoid != null)
            {
                strSql1.Append("cSourceAutoid,");
                strSql2.Append("'" + model.cSourceAutoid + "',");
            }
            strSql.Append("insert into @u8.Ven_Inv_Price(");
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
        public string Update(Purchase.Model.Ven_Inv_Price model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.Ven_Inv_Price set ");
            if (model.cVenCode != null)
            {
                strSql.Append("cVenCode='" + model.cVenCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql.Append("cInvCode='" + model.cInvCode + "',");
            }
            if (model.dEnableDate != null)
            {
                strSql.Append("dEnableDate='" + model.dEnableDate + "',");
            }
            if (model.dDisableDate != null)
            {
                strSql.Append("dDisableDate='" + model.dDisableDate + "',");
            }
            else
            {
                strSql.Append("dDisableDate= null ,");
            }
            if (model.cExch_Name != null)
            {
                strSql.Append("cExch_Name='" + model.cExch_Name + "',");
            }
            else
            {
                strSql.Append("cExch_Name= null ,");
            }
            if (model.bPromotion != null)
            {
                strSql.Append("bPromotion=" + model.bPromotion + ",");
            }
            if (model.cMemo != null)
            {
                strSql.Append("cMemo='" + model.cMemo + "',");
            }
            else
            {
                strSql.Append("cMemo= null ,");
            }
            if (model.iSupplyType != null)
            {
                strSql.Append("iSupplyType=" + model.iSupplyType + ",");
            }
            if (model.btaxcost != null)
            {
                strSql.Append("btaxcost=" + model.btaxcost + ",");
            }
            if (model.cTermCode != null)
            {
                strSql.Append("cTermCode='" + model.cTermCode + "',");
            }
            else
            {
                strSql.Append("cTermCode= null ,");
            }
            if (model.iLowerLimit != null)
            {
                strSql.Append("iLowerLimit=" + model.iLowerLimit + ",");
            }
            if (model.iUpperLimit != null)
            {
                strSql.Append("iUpperLimit=" + model.iUpperLimit + ",");
            }
            else
            {
                strSql.Append("iUpperLimit= null ,");
            }
            if (model.iUnitPrice != null)
            {
                strSql.Append("iUnitPrice=" + model.iUnitPrice + ",");
            }
            if (model.iTaxRate != null)
            {
                strSql.Append("iTaxRate=" + model.iTaxRate + ",");
            }
            if (model.iTaxUnitPrice != null)
            {
                strSql.Append("iTaxUnitPrice=" + model.iTaxUnitPrice + ",");
            }
            if (model.ipriceautoid != null)
            {
                strSql.Append("ipriceautoid=" + model.ipriceautoid + ",");
            }
            else
            {
                strSql.Append("ipriceautoid= null ,");
            }
            if (model.cfree1 != null)
            {
                strSql.Append("cfree1='" + model.cfree1 + "',");
            }
            else
            {
                strSql.Append("cfree1= null ,");
            }
            if (model.cfree2 != null)
            {
                strSql.Append("cfree2='" + model.cfree2 + "',");
            }
            else
            {
                strSql.Append("cfree2= null ,");
            }
            if (model.cfree3 != null)
            {
                strSql.Append("cfree3='" + model.cfree3 + "',");
            }
            else
            {
                strSql.Append("cfree3= null ,");
            }
            if (model.cfree4 != null)
            {
                strSql.Append("cfree4='" + model.cfree4 + "',");
            }
            else
            {
                strSql.Append("cfree4= null ,");
            }
            if (model.cfree5 != null)
            {
                strSql.Append("cfree5='" + model.cfree5 + "',");
            }
            else
            {
                strSql.Append("cfree5= null ,");
            }
            if (model.cfree6 != null)
            {
                strSql.Append("cfree6='" + model.cfree6 + "',");
            }
            else
            {
                strSql.Append("cfree6= null ,");
            }
            if (model.cfree7 != null)
            {
                strSql.Append("cfree7='" + model.cfree7 + "',");
            }
            else
            {
                strSql.Append("cfree7= null ,");
            }
            if (model.cfree8 != null)
            {
                strSql.Append("cfree8='" + model.cfree8 + "',");
            }
            else
            {
                strSql.Append("cfree8= null ,");
            }
            if (model.cfree9 != null)
            {
                strSql.Append("cfree9='" + model.cfree9 + "',");
            }
            else
            {
                strSql.Append("cfree9= null ,");
            }
            if (model.cfree10 != null)
            {
                strSql.Append("cfree10='" + model.cfree10 + "',");
            }
            else
            {
                strSql.Append("cfree10= null ,");
            }
            if (model.cSource != null)
            {
                strSql.Append("cSource='" + model.cSource + "',");
            }
            else
            {
                strSql.Append("cSource= null ,");
            }
            if (model.cSourceCode != null)
            {
                strSql.Append("cSourceCode='" + model.cSourceCode + "',");
            }
            else
            {
                strSql.Append("cSourceCode= null ,");
            }
            if (model.cSourceAutoid != null)
            {
                strSql.Append("cSourceAutoid='" + model.cSourceAutoid + "',");
            }
            else
            {
                strSql.Append("cSourceAutoid= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where Autoid=" + model.Autoid + "");
            return (strSql.ToString());

        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

