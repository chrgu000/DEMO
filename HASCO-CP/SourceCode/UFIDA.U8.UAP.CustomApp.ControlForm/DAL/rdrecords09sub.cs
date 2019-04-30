using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:rdrecords09sub
    /// </summary>
    public partial class rdrecords09sub
    {
        public rdrecords09sub()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.rdrecords09sub model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.AutoID != null)
            {
                strSql1.Append("AutoID,");
                strSql2.Append("" + model.AutoID + ",");
            }
            if (model.ID != null)
            {
                strSql1.Append("ID,");
                strSql2.Append("" + model.ID + ",");
            }
            if (model.cBG_ItemCode != null)
            {
                strSql1.Append("cBG_ItemCode,");
                strSql2.Append("'" + model.cBG_ItemCode + "',");
            }
            if (model.cBG_ItemName != null)
            {
                strSql1.Append("cBG_ItemName,");
                strSql2.Append("'" + model.cBG_ItemName + "',");
            }
            if (model.cBG_CaliberKey1 != null)
            {
                strSql1.Append("cBG_CaliberKey1,");
                strSql2.Append("'" + model.cBG_CaliberKey1 + "',");
            }
            if (model.cBG_CaliberKeyName1 != null)
            {
                strSql1.Append("cBG_CaliberKeyName1,");
                strSql2.Append("'" + model.cBG_CaliberKeyName1 + "',");
            }
            if (model.cBG_CaliberKey2 != null)
            {
                strSql1.Append("cBG_CaliberKey2,");
                strSql2.Append("'" + model.cBG_CaliberKey2 + "',");
            }
            if (model.cBG_CaliberKeyName2 != null)
            {
                strSql1.Append("cBG_CaliberKeyName2,");
                strSql2.Append("'" + model.cBG_CaliberKeyName2 + "',");
            }
            if (model.cBG_CaliberKey3 != null)
            {
                strSql1.Append("cBG_CaliberKey3,");
                strSql2.Append("'" + model.cBG_CaliberKey3 + "',");
            }
            if (model.cBG_CaliberKeyName3 != null)
            {
                strSql1.Append("cBG_CaliberKeyName3,");
                strSql2.Append("'" + model.cBG_CaliberKeyName3 + "',");
            }
            if (model.cBG_CaliberCode1 != null)
            {
                strSql1.Append("cBG_CaliberCode1,");
                strSql2.Append("'" + model.cBG_CaliberCode1 + "',");
            }
            if (model.cBG_CaliberName1 != null)
            {
                strSql1.Append("cBG_CaliberName1,");
                strSql2.Append("'" + model.cBG_CaliberName1 + "',");
            }
            if (model.cBG_CaliberCode2 != null)
            {
                strSql1.Append("cBG_CaliberCode2,");
                strSql2.Append("'" + model.cBG_CaliberCode2 + "',");
            }
            if (model.cBG_CaliberName2 != null)
            {
                strSql1.Append("cBG_CaliberName2,");
                strSql2.Append("'" + model.cBG_CaliberName2 + "',");
            }
            if (model.cBG_CaliberCode3 != null)
            {
                strSql1.Append("cBG_CaliberCode3,");
                strSql2.Append("'" + model.cBG_CaliberCode3 + "',");
            }
            if (model.cBG_CaliberName3 != null)
            {
                strSql1.Append("cBG_CaliberName3,");
                strSql2.Append("'" + model.cBG_CaliberName3 + "',");
            }
            if (model.iBG_Ctrl != null)
            {
                strSql1.Append("iBG_Ctrl,");
                strSql2.Append("" + (model.iBG_Ctrl ? 1 : 0) + ",");
            }
            if (model.cBG_Auditopinion != null)
            {
                strSql1.Append("cBG_Auditopinion,");
                strSql2.Append("'" + model.cBG_Auditopinion + "',");
            }
            if (model.iBGSTSum != null)
            {
                strSql1.Append("iBGSTSum,");
                strSql2.Append("" + model.iBGSTSum + ",");
            }
            if (model.iBGIASum != null)
            {
                strSql1.Append("iBGIASum,");
                strSql2.Append("" + model.iBGIASum + ",");
            }
            if (model.cBG_CaliberKey4 != null)
            {
                strSql1.Append("cBG_CaliberKey4,");
                strSql2.Append("'" + model.cBG_CaliberKey4 + "',");
            }
            if (model.cBG_CaliberKeyName4 != null)
            {
                strSql1.Append("cBG_CaliberKeyName4,");
                strSql2.Append("'" + model.cBG_CaliberKeyName4 + "',");
            }
            if (model.cBG_CaliberKey5 != null)
            {
                strSql1.Append("cBG_CaliberKey5,");
                strSql2.Append("'" + model.cBG_CaliberKey5 + "',");
            }
            if (model.cBG_CaliberKeyName5 != null)
            {
                strSql1.Append("cBG_CaliberKeyName5,");
                strSql2.Append("'" + model.cBG_CaliberKeyName5 + "',");
            }
            if (model.cBG_CaliberKey6 != null)
            {
                strSql1.Append("cBG_CaliberKey6,");
                strSql2.Append("'" + model.cBG_CaliberKey6 + "',");
            }
            if (model.cBG_CaliberKeyName6 != null)
            {
                strSql1.Append("cBG_CaliberKeyName6,");
                strSql2.Append("'" + model.cBG_CaliberKeyName6 + "',");
            }
            if (model.cBG_CaliberCode4 != null)
            {
                strSql1.Append("cBG_CaliberCode4,");
                strSql2.Append("'" + model.cBG_CaliberCode4 + "',");
            }
            if (model.cBG_CaliberName4 != null)
            {
                strSql1.Append("cBG_CaliberName4,");
                strSql2.Append("'" + model.cBG_CaliberName4 + "',");
            }
            if (model.cBG_CaliberCode5 != null)
            {
                strSql1.Append("cBG_CaliberCode5,");
                strSql2.Append("'" + model.cBG_CaliberCode5 + "',");
            }
            if (model.cBG_CaliberName5 != null)
            {
                strSql1.Append("cBG_CaliberName5,");
                strSql2.Append("'" + model.cBG_CaliberName5 + "',");
            }
            if (model.cBG_CaliberCode6 != null)
            {
                strSql1.Append("cBG_CaliberCode6,");
                strSql2.Append("'" + model.cBG_CaliberCode6 + "',");
            }
            if (model.cBG_CaliberName6 != null)
            {
                strSql1.Append("cBG_CaliberName6,");
                strSql2.Append("'" + model.cBG_CaliberName6 + "',");
            }
            strSql.Append("insert into rdrecords09sub(");
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

