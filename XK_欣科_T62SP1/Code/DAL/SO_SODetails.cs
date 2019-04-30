using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:SO_SODetails
    /// </summary>
    public partial class SO_SODetails
    {
        public SO_SODetails()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.SO_SODetails model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cSOCode != null)
            {
                strSql1.Append("cSOCode,");
                strSql2.Append("'" + model.cSOCode + "',");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.dPreDate != null)
            {
                strSql1.Append("dPreDate,");
                strSql2.Append("'" + model.dPreDate + "',");
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
            if (model.iFHNum != null)
            {
                strSql1.Append("iFHNum,");
                strSql2.Append("" + model.iFHNum + ",");
            }
            if (model.iFHQuantity != null)
            {
                strSql1.Append("iFHQuantity,");
                strSql2.Append("" + model.iFHQuantity + ",");
            }
            if (model.iFHMoney != null)
            {
                strSql1.Append("iFHMoney,");
                strSql2.Append("" + model.iFHMoney + ",");
            }
            if (model.iKPQuantity != null)
            {
                strSql1.Append("iKPQuantity,");
                strSql2.Append("" + model.iKPQuantity + ",");
            }
            if (model.iKPNum != null)
            {
                strSql1.Append("iKPNum,");
                strSql2.Append("" + model.iKPNum + ",");
            }
            if (model.iKPMoney != null)
            {
                strSql1.Append("iKPMoney,");
                strSql2.Append("" + model.iKPMoney + ",");
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
            if (model.bFH != null)
            {
                strSql1.Append("bFH,");
                strSql2.Append("" + model.bFH + ",");
            }
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
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
            if (model.iInvExchRate != null)
            {
                strSql1.Append("iInvExchRate,");
                strSql2.Append("" + model.iInvExchRate + ",");
            }
            if (model.cUnitID != null)
            {
                strSql1.Append("cUnitID,");
                strSql2.Append("'" + model.cUnitID + "',");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
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
            if (model.FPurQuan != null)
            {
                strSql1.Append("FPurQuan,");
                strSql2.Append("" + model.FPurQuan + ",");
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
            if (model.BomID != null)
            {
                strSql1.Append("BomID,");
                strSql2.Append("'" + model.BomID + "',");
            }
            if (model.dPreFinishDate != null)
            {
                strSql1.Append("dPreFinishDate,");
                strSql2.Append("'" + model.dPreFinishDate + "',");
            }
            if (model.fTotolPut != null)
            {
                strSql1.Append("fTotolPut,");
                strSql2.Append("" + model.fTotolPut + ",");
            }
            if (model.cbomsocode != null)
            {
                strSql1.Append("cbomsocode,");
                strSql2.Append("'" + model.cbomsocode + "',");
            }
            if (model.fTotolPutNum != null)
            {
                strSql1.Append("fTotolPutNum,");
                strSql2.Append("" + model.fTotolPutNum + ",");
            }
            if (model.bMRPs != null)
            {
                strSql1.Append("bMRPs,");
                strSql2.Append("" + model.bMRPs + ",");
            }
            if (model.iMPQuantity != null)
            {
                strSql1.Append("iMPQuantity,");
                strSql2.Append("" + model.iMPQuantity + ",");
            }
            if (model.iNetMPQuantity != null)
            {
                strSql1.Append("iNetMPQuantity,");
                strSql2.Append("" + model.iNetMPQuantity + ",");
            }
            strSql.Append("insert into @u8.SO_SODetails(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

