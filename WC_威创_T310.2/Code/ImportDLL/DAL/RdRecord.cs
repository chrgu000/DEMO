using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ImportDLL.DAL
{
    /// <summary>
    /// 数据访问类:RdRecord
    /// </summary>
    public partial class RdRecord
    {
        public RdRecord()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int ID, int bRdFlag, string cVouchType, string cWhCode, DateTime dDate, string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RdRecord");
            strSql.Append(" where ID=" + ID + " and bRdFlag=" + bRdFlag + " and cVouchType='" + cVouchType + "' and cWhCode='" + cWhCode + "' and dDate='" + dDate + "' and cCode='" + cCode + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ImportDLL.Model.RdRecord model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.bRdFlag != null)
            {
                strSql1.Append("bRdFlag,");
                strSql2.Append("" + model.bRdFlag + ",");
            }
            if (model.cVouchType != null)
            {
                strSql1.Append("cVouchType,");
                strSql2.Append("'" + model.cVouchType + "',");
            }
            if (model.cBusType != null)
            {
                strSql1.Append("cBusType,");
                strSql2.Append("'" + model.cBusType + "',");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cBusCode != null)
            {
                strSql1.Append("cBusCode,");
                strSql2.Append("'" + model.cBusCode + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.dDate != null)
            {
                strSql1.Append("dDate,");
                strSql2.Append("'" + model.dDate + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cRdCode != null)
            {
                strSql1.Append("cRdCode,");
                strSql2.Append("'" + model.cRdCode + "',");
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
            if (model.cPTCode != null)
            {
                strSql1.Append("cPTCode,");
                strSql2.Append("'" + model.cPTCode + "',");
            }
            if (model.cSTCode != null)
            {
                strSql1.Append("cSTCode,");
                strSql2.Append("'" + model.cSTCode + "',");
            }
            if (model.cCusCode != null)
            {
                strSql1.Append("cCusCode,");
                strSql2.Append("'" + model.cCusCode + "',");
            }
            if (model.cVenCode != null)
            {
                strSql1.Append("cVenCode,");
                strSql2.Append("'" + model.cVenCode + "',");
            }
            if (model.cOrderCode != null)
            {
                strSql1.Append("cOrderCode,");
                strSql2.Append("'" + model.cOrderCode + "',");
            }
            if (model.cARVCode != null)
            {
                strSql1.Append("cARVCode,");
                strSql2.Append("'" + model.cARVCode + "',");
            }
            if (model.cBillCode != null)
            {
                strSql1.Append("cBillCode,");
                strSql2.Append("" + model.cBillCode + ",");
            }
            if (model.cDLCode != null)
            {
                strSql1.Append("cDLCode,");
                strSql2.Append("" + model.cDLCode + ",");
            }
            if (model.cProBatch != null)
            {
                strSql1.Append("cProBatch,");
                strSql2.Append("'" + model.cProBatch + "',");
            }
            if (model.cHandler != null)
            {
                strSql1.Append("cHandler,");
                strSql2.Append("'" + model.cHandler + "',");
            }
            if (model.cMemo != null)
            {
                strSql1.Append("cMemo,");
                strSql2.Append("'" + model.cMemo + "',");
            }
            if (model.bTransFlag != null)
            {
                strSql1.Append("bTransFlag,");
                strSql2.Append("" + (model.bTransFlag ? 1 : 0) + ",");
            }
            if (model.cAccounter != null)
            {
                strSql1.Append("cAccounter,");
                strSql2.Append("'" + model.cAccounter + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
            }
            if (model.iNetLock != null)
            {
                strSql1.Append("iNetLock,");
                strSql2.Append("" + model.iNetLock + ",");
            }
            if (model.cDefine1 != null)
            {
                strSql1.Append("cDefine1,");
                strSql2.Append("'" + model.cDefine1 + "',");
            }
            if (model.cDefine2 != null)
            {
                strSql1.Append("cDefine2,");
                strSql2.Append("'" + model.cDefine2 + "',");
            }
            if (model.cDefine3 != null)
            {
                strSql1.Append("cDefine3,");
                strSql2.Append("'" + model.cDefine3 + "',");
            }
            if (model.cDefine4 != null)
            {
                strSql1.Append("cDefine4,");
                strSql2.Append("'" + model.cDefine4 + "',");
            }
            if (model.cDefine5 != null)
            {
                strSql1.Append("cDefine5,");
                strSql2.Append("" + model.cDefine5 + ",");
            }
            if (model.cDefine6 != null)
            {
                strSql1.Append("cDefine6,");
                strSql2.Append("'" + model.cDefine6 + "',");
            }
            if (model.cDefine7 != null)
            {
                strSql1.Append("cDefine7,");
                strSql2.Append("" + model.cDefine7 + ",");
            }
            if (model.cDefine8 != null)
            {
                strSql1.Append("cDefine8,");
                strSql2.Append("'" + model.cDefine8 + "',");
            }
            if (model.cDefine9 != null)
            {
                strSql1.Append("cDefine9,");
                strSql2.Append("'" + model.cDefine9 + "',");
            }
            if (model.cDefine10 != null)
            {
                strSql1.Append("cDefine10,");
                strSql2.Append("'" + model.cDefine10 + "',");
            }
            if (model.dKeepDate != null)
            {
                strSql1.Append("dKeepDate,");
                strSql2.Append("'" + model.dKeepDate + "',");
            }
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.iTaxRateHead != null)
            {
                strSql1.Append("iTaxRateHead,");
                strSql2.Append("" + model.iTaxRateHead + ",");
            }
            if (model.cSCCode != null)
            {
                strSql1.Append("cSCCode,");
                strSql2.Append("'" + model.cSCCode + "',");
            }
            if (model.cShipAddress != null)
            {
                strSql1.Append("cShipAddress,");
                strSql2.Append("'" + model.cShipAddress + "',");
            }
            if (model.cZQCode != null)
            {
                strSql1.Append("cZQCode,");
                strSql2.Append("'" + model.cZQCode + "',");
            }
            if (model.dZQDate != null)
            {
                strSql1.Append("dZQDate,");
                strSql2.Append("'" + model.dZQDate + "',");
            }
            strSql.Append("insert into RdRecord(");
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

