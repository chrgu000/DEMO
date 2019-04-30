using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace ClsU8.DAL
{
    /// <summary>
    /// 数据访问类:MaterialAppVouch
    /// </summary>
    public partial class MaterialAppVouch
    {
        public MaterialAppVouch()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(ClsU8.Model.MaterialAppVouch model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
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
            if (model.cItem_class != null)
            {
                strSql1.Append("cItem_class,");
                strSql2.Append("'" + model.cItem_class + "',");
            }
            if (model.cItemCode != null)
            {
                strSql1.Append("cItemCode,");
                strSql2.Append("'" + model.cItemCode + "',");
            }
            if (model.cName != null)
            {
                strSql1.Append("cName,");
                strSql2.Append("'" + model.cName + "',");
            }
            if (model.cItemCName != null)
            {
                strSql1.Append("cItemCName,");
                strSql2.Append("'" + model.cItemCName + "',");
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
            if (model.cCloser != null)
            {
                strSql1.Append("cCloser,");
                strSql2.Append("'" + model.cCloser + "',");
            }
            if (model.cMaker != null)
            {
                strSql1.Append("cMaker,");
                strSql2.Append("'" + model.cMaker + "',");
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
            if (model.dVeriDate != null)
            {
                strSql1.Append("dVeriDate,");
                strSql2.Append("'" + model.dVeriDate + "',");
            }
            if (model.VT_ID != null)
            {
                strSql1.Append("VT_ID,");
                strSql2.Append("" + model.VT_ID + ",");
            }
            if (model.cDefine11 != null)
            {
                strSql1.Append("cDefine11,");
                strSql2.Append("'" + model.cDefine11 + "',");
            }
            if (model.cDefine12 != null)
            {
                strSql1.Append("cDefine12,");
                strSql2.Append("'" + model.cDefine12 + "',");
            }
            if (model.cDefine13 != null)
            {
                strSql1.Append("cDefine13,");
                strSql2.Append("'" + model.cDefine13 + "',");
            }
            if (model.cDefine14 != null)
            {
                strSql1.Append("cDefine14,");
                strSql2.Append("'" + model.cDefine14 + "',");
            }
            if (model.cDefine15 != null)
            {
                strSql1.Append("cDefine15,");
                strSql2.Append("" + model.cDefine15 + ",");
            }
            if (model.cDefine16 != null)
            {
                strSql1.Append("cDefine16,");
                strSql2.Append("" + model.cDefine16 + ",");
            }
            if (model.ufts != null)
            {
                strSql1.Append("ufts,");
                strSql2.Append("" + model.ufts + ",");
            }
            if (model.ireturncount != null)
            {
                strSql1.Append("ireturncount,");
                strSql2.Append("" + model.ireturncount + ",");
            }
            if (model.iverifystate != null)
            {
                strSql1.Append("iverifystate,");
                strSql2.Append("" + model.iverifystate + ",");
            }
            if (model.iswfcontrolled != null)
            {
                strSql1.Append("iswfcontrolled,");
                strSql2.Append("" + model.iswfcontrolled + ",");
            }
            if (model.cModifyPerson != null)
            {
                strSql1.Append("cModifyPerson,");
                strSql2.Append("'" + model.cModifyPerson + "',");
            }
            if (model.dModifyDate != null)
            {
                strSql1.Append("dModifyDate,");
                strSql2.Append("'" + model.dModifyDate + "',");
            }
            if (model.dnmaketime != null)
            {
                strSql1.Append("dnmaketime,");
                strSql2.Append("'" + model.dnmaketime + "',");
            }
            if (model.dnmodifytime != null)
            {
                strSql1.Append("dnmodifytime,");
                strSql2.Append("'" + model.dnmodifytime + "',");
            }
            if (model.dnverifytime != null)
            {
                strSql1.Append("dnverifytime,");
                strSql2.Append("'" + model.dnverifytime + "',");
            }
            if (model.iPrintCount != null)
            {
                strSql1.Append("iPrintCount,");
                strSql2.Append("" + model.iPrintCount + ",");
            }
            if (model.cSource != null)
            {
                strSql1.Append("cSource,");
                strSql2.Append("'" + model.cSource + "',");
            }
            if (model.cvencode != null)
            {
                strSql1.Append("cvencode,");
                strSql2.Append("'" + model.cvencode + "',");
            }
            if (model.imquantity != null)
            {
                strSql1.Append("imquantity,");
                strSql2.Append("" + model.imquantity + ",");
            }
            if (model.csysbarcode != null)
            {
                strSql1.Append("csysbarcode,");
                strSql2.Append("'" + model.csysbarcode + "',");
            }
            if (model.cCurrentAuditor != null)
            {
                strSql1.Append("cCurrentAuditor,");
                strSql2.Append("'" + model.cCurrentAuditor + "',");
            }
            if (model.cChanger != null)
            {
                strSql1.Append("cChanger,");
                strSql2.Append("'" + model.cChanger + "',");
            }
            strSql.Append("insert into MaterialAppVouch(");
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

