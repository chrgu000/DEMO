using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH.BaseClass;
using System.Data;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public class DAL_BarCodeRD
    {
        public DAL_BarCodeRD()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model_BarCodeRD model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.sCode != null)
            {
                strSql1.Append("sCode,");
                strSql2.Append("'" + model.sCode + "',");
            }
            if (model.BarCode != null)
            {
                strSql1.Append("BarCode,");
                strSql2.Append("'" + model.BarCode + "',");
            }
            if (model.XBarCode != null)
            {
                strSql1.Append("XBarCode,");
                strSql2.Append("'" + model.XBarCode + "',");
            }
            if (model.sType != null)
            {
                strSql1.Append("sType,");
                strSql2.Append("'" + model.sType + "',");
            }
            if (model.ExsID != null)
            {
                strSql1.Append("ExsID,");
                strSql2.Append("" + model.ExsID + ",");
            }
            if (model.ExCode != null)
            {
                strSql1.Append("ExCode,");
                strSql2.Append("'" + model.ExCode + "',");
            }
            if (model.ExRowNo != null)
            {
                strSql1.Append("ExRowNo,");
                strSql2.Append("" + model.ExRowNo + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.RDType != null)
            {
                strSql1.Append("RDType,");
                strSql2.Append("" + model.RDType + ",");
            }
            strSql.Append("insert into _BarCodeRD(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }
		#endregion  Method
	}
}

