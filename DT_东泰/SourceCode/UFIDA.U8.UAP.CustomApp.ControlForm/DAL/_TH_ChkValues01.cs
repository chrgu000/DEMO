using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_TH_ChkValues01
    /// </summary>
    public partial class _TH_ChkValues01
    {
        public _TH_ChkValues01()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._TH_ChkValues01 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.WONo != null)
            {
                strSql1.Append("WONo,");
                strSql2.Append("'" + model.WONo + "',");
            }
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.WorkProcess != null)
            {
                strSql1.Append("WorkProcess,");
                strSql2.Append("'" + model.WorkProcess + "',");
            }
            if (model.WorkGroup != null)
            {
                strSql1.Append("WorkGroup,");
                strSql2.Append("'" + model.WorkGroup + "',");
            }
            if (model.MODid != null)
            {
                strSql1.Append("MODid,");
                strSql2.Append("" + model.MODid + ",");
            }
            if (model.chkItemCode != null)
            {
                strSql1.Append("chkItemCode,");
                strSql2.Append("'" + model.chkItemCode + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.chkItemName != null)
            {
                strSql1.Append("chkItemName,");
                strSql2.Append("'" + model.chkItemName + "',");
            }

            if (model.chkMax != null)
            {
                strSql1.Append("chkMax,");
                strSql2.Append("" + model.chkMax + ",");
            }
            if (model.chkMin != null)
            {
                strSql1.Append("chkMin,");
                strSql2.Append("" + model.chkMin + ",");
            }
            if (model.chkValue01 != null)
            {
                strSql1.Append("chkValue01,");
                strSql2.Append("" + model.chkValue01 + ",");
            }
            if (model.chkValue02 != null)
            {
                strSql1.Append("chkValue02,");
                strSql2.Append("" + model.chkValue02 + ",");
            }
            if (model.chkValue03 != null)
            {
                strSql1.Append("chkValue03,");
                strSql2.Append("" + model.chkValue03 + ",");
            }
            if (model.chkValue04 != null)
            {
                strSql1.Append("chkValue04,");
                strSql2.Append("" + model.chkValue04 + ",");
            }
            if (model.chkValue05 != null)
            {
                strSql1.Append("chkValue05,");
                strSql2.Append("" + model.chkValue05 + ",");
            }
            if (model.chkValue06 != null)
            {
                strSql1.Append("chkValue06,");
                strSql2.Append("" + model.chkValue06 + ",");
            }
            if (model.chkValue07 != null)
            {
                strSql1.Append("chkValue07,");
                strSql2.Append("" + model.chkValue07 + ",");
            }
            if (model.chkValue08 != null)
            {
                strSql1.Append("chkValue08,");
                strSql2.Append("" + model.chkValue08 + ",");
            }
            if (model.chkValue09 != null)
            {
                strSql1.Append("chkValue09,");
                strSql2.Append("" + model.chkValue09 + ",");
            }
            if (model.chkValue10 != null)
            {
                strSql1.Append("chkValue10,");
                strSql2.Append("" + model.chkValue10 + ",");
            }
            if (model.chkValue11 != null)
            {
                strSql1.Append("chkValue11,");
                strSql2.Append("" + model.chkValue11 + ",");
            }
            if (model.chkValue12 != null)
            {
                strSql1.Append("chkValue12,");
                strSql2.Append("" + model.chkValue12 + ",");
            }
            if (model.chkValue13 != null)
            {
                strSql1.Append("chkValue13,");
                strSql2.Append("" + model.chkValue13 + ",");
            }
            if (model.chkValue14 != null)
            {
                strSql1.Append("chkValue14,");
                strSql2.Append("" + model.chkValue14 + ",");
            }
            if (model.chkValue15 != null)
            {
                strSql1.Append("chkValue15,");
                strSql2.Append("" + model.chkValue15 + ",");
            }
            if (model.chkValue16 != null)
            {
                strSql1.Append("chkValue16,");
                strSql2.Append("" + model.chkValue16 + ",");
            }
            if (model.chkValue17 != null)
            {
                strSql1.Append("chkValue17,");
                strSql2.Append("" + model.chkValue17 + ",");
            }
            if (model.chkValue18 != null)
            {
                strSql1.Append("chkValue18,");
                strSql2.Append("" + model.chkValue18 + ",");
            }
            if (model.chkValue19 != null)
            {
                strSql1.Append("chkValue19,");
                strSql2.Append("" + model.chkValue19 + ",");
            }
            if (model.chkValue20 != null)
            {
                strSql1.Append("chkValue20,");
                strSql2.Append("" + model.chkValue20 + ",");
            }
            if (model.chkValue21 != null)
            {
                strSql1.Append("chkValue21,");
                strSql2.Append("" + model.chkValue21 + ",");
            }
            if (model.chkValue22 != null)
            {
                strSql1.Append("chkValue22,");
                strSql2.Append("" + model.chkValue22 + ",");
            }
            if (model.chkValue23 != null)
            {
                strSql1.Append("chkValue23,");
                strSql2.Append("" + model.chkValue23 + ",");
            }
            if (model.chkValue24 != null)
            {
                strSql1.Append("chkValue24,");
                strSql2.Append("" + model.chkValue24 + ",");
            }
            if (model.chkValue25 != null)
            {
                strSql1.Append("chkValue25,");
                strSql2.Append("" + model.chkValue25 + ",");
            }
            if (model.chkValue26 != null)
            {
                strSql1.Append("chkValue26,");
                strSql2.Append("" + model.chkValue26 + ",");
            }
            if (model.chkValue27 != null)
            {
                strSql1.Append("chkValue27,");
                strSql2.Append("" + model.chkValue27 + ",");
            }
            if (model.chkValue28 != null)
            {
                strSql1.Append("chkValue28,");
                strSql2.Append("" + model.chkValue28 + ",");
            }
            if (model.chkValue29 != null)
            {
                strSql1.Append("chkValue29,");
                strSql2.Append("" + model.chkValue29 + ",");
            }
            if (model.chkValue30 != null)
            {
                strSql1.Append("chkValue30,");
                strSql2.Append("" + model.chkValue30 + ",");
            }
            //if (model.PassOrNG != null)
            //{
                strSql1.Append("PassOrNG,");
                strSql2.Append("" + (model.PassOrNG ? 1 : 0) + ",");
            //}
            strSql.Append("insert into _TH_ChkValues01(");
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

