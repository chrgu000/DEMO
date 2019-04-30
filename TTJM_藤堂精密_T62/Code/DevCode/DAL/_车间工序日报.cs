using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:BarCodeList
    /// </summary>
    public partial class _车间工序日报
    {
        public _车间工序日报()
        { }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model._车间工序日报 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MainID != null)
            {
                strSql1.Append("MainID,");
                strSql2.Append("" + model.MainID + ",");
            }
            if (model.MoCode != null)
            {
                strSql1.Append("MoCode,");
                strSql2.Append("'" + model.MoCode + "',");
            }
            if (model.dtm != null)
            {
                strSql1.Append("dtm,");
                strSql2.Append("'" + model.dtm + "',");
            }
            if (model.BoxNO != null)
            {
                strSql1.Append("BoxNO,");
                strSql2.Append("" + model.BoxNO + ",");
            }
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cInvName != null)
            {
                strSql1.Append("cInvName,");
                strSql2.Append("'" + model.cInvName + "',");
            }
            if (model.cInvStd != null)
            {
                strSql1.Append("cInvStd,");
                strSql2.Append("'" + model.cInvStd + "',");
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
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.CloseUid != null)
            {
                strSql1.Append("CloseUid,");
                strSql2.Append("'" + model.CloseUid + "',");
            }
            if (model.CloseDate != null)
            {
                strSql1.Append("CloseDate,");
                strSql2.Append("'" + model.CloseDate + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.Remark2 != null)
            {
                strSql1.Append("Remark2,");
                strSql2.Append("'" + model.Remark2 + "',");
            }
            if (model.Remark3 != null)
            {
                strSql1.Append("Remark3,");
                strSql2.Append("'" + model.Remark3 + "',");
            }
            if (model.Remark4 != null)
            {
                strSql1.Append("Remark4,");
                strSql2.Append("'" + model.Remark4 + "',");
            }
            if (model.Remark5 != null)
            {
                strSql1.Append("Remark5,");
                strSql2.Append("'" + model.Remark5 + "',");
            }
            if (model.Remark6 != null)
            {
                strSql1.Append("Remark6,");
                strSql2.Append("'" + model.Remark6 + "',");
            }
            if (model.Remark7 != null)
            {
                strSql1.Append("Remark7,");
                strSql2.Append("'" + model.Remark7 + "',");
            }
            if (model.Remark8 != null)
            {
                strSql1.Append("Remark8,");
                strSql2.Append("'" + model.Remark8 + "',");
            }
            if (model.Remark9 != null)
            {
                strSql1.Append("Remark9,");
                strSql2.Append("'" + model.Remark9 + "',");
            }
            if (model.Remark10 != null)
            {
                strSql1.Append("Remark10,");
                strSql2.Append("'" + model.Remark10 + "',");
            }
            if (model.GX1 != null)
            {
                strSql1.Append("GX1,");
                strSql2.Append("" + model.GX1 + ",");
            }
            if (model.GX2 != null)
            {
                strSql1.Append("GX2,");
                strSql2.Append("" + model.GX2 + ",");
            }
            if (model.GX3 != null)
            {
                strSql1.Append("GX3,");
                strSql2.Append("" + model.GX3 + ",");
            }
            if (model.GX4 != null)
            {
                strSql1.Append("GX4,");
                strSql2.Append("" + model.GX4 + ",");
            }
            if (model.GX5 != null)
            {
                strSql1.Append("GX5,");
                strSql2.Append("" + model.GX5 + ",");
            }
            if (model.GX6 != null)
            {
                strSql1.Append("GX6,");
                strSql2.Append("" + model.GX6 + ",");
            }
            if (model.GX7 != null)
            {
                strSql1.Append("GX7,");
                strSql2.Append("" + model.GX7 + ",");
            }
            if (model.GX8 != null)
            {
                strSql1.Append("GX8,");
                strSql2.Append("" + model.GX8 + ",");
            }
            if (model.GX9 != null)
            {
                strSql1.Append("GX9,");
                strSql2.Append("" + model.GX9 + ",");
            }
            if (model.GX10 != null)
            {
                strSql1.Append("GX10,");
                strSql2.Append("" + model.GX10 + ",");
            }
            if (model.GX11 != null)
            {
                strSql1.Append("GX11,");
                strSql2.Append("" + model.GX11 + ",");
            }
            if (model.GX12 != null)
            {
                strSql1.Append("GX12,");
                strSql2.Append("" + model.GX12 + ",");
            }
            if (model.GX13 != null)
            {
                strSql1.Append("GX13,");
                strSql2.Append("" + model.GX13 + ",");
            }
            if (model.GX14 != null)
            {
                strSql1.Append("GX14,");
                strSql2.Append("" + model.GX14 + ",");
            }
            if (model.GX15 != null)
            {
                strSql1.Append("GX15,");
                strSql2.Append("" + model.GX15 + ",");
            }
            if (model.GX16 != null)
            {
                strSql1.Append("GX16,");
                strSql2.Append("" + model.GX16 + ",");
            }
            if (model.GX17 != null)
            {
                strSql1.Append("GX17,");
                strSql2.Append("" + model.GX17 + ",");
            }
            if (model.GX18 != null)
            {
                strSql1.Append("GX18,");
                strSql2.Append("" + model.GX18 + ",");
            }
            if (model.GX19 != null)
            {
                strSql1.Append("GX19,");
                strSql2.Append("" + model.GX19 + ",");
            }
            if (model.GX20 != null)
            {
                strSql1.Append("GX20,");
                strSql2.Append("" + model.GX20 + ",");
            }
            strSql.Append("insert into _车间工序日报(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

		
    }
}

