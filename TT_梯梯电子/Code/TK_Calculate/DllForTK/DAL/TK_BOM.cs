using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DllForTK.DAL
{
    /// <summary>
    /// 数据访问类:TK_BOM
    /// </summary>
    public partial class TK_BOM
    {
        public TK_BOM()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(DllForTK.Model.TK_BOM model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.depth != null)
            {
                strSql1.Append("depth,");
                strSql2.Append("N'" + model.depth + "',");
            }
            if (model.toplevel != null)
            {
                strSql1.Append("toplevel,");
                strSql2.Append("N'" + model.toplevel + "',");
            }
            if (model.parent != null)
            {
                strSql1.Append("parent,");
                strSql2.Append("N'" + model.parent + "',");
            }
            if (model.child != null)
            {
                strSql1.Append("child,");
                strSql2.Append("N'" + model.child + "',");
            }
            if (model.qty != null)
            {
                strSql1.Append("qty,");
                strSql2.Append("" + model.qty + ",");
            }
            if (model.cumqty != null)
            {
                strSql1.Append("cumqty,");
                strSql2.Append("" + model.cumqty + ",");
            }
            if (model.childsm != null)
            {
                strSql1.Append("childsm,");
                strSql2.Append("N'" + model.childsm + "',");
            }
            if (model.topprodgroup != null)
            {
                strSql1.Append("topprodgroup,");
                strSql2.Append("N'" + model.topprodgroup + "',");
            }
            if (model.CommonParts != null)
            {
                strSql1.Append("CommonParts,");
                strSql2.Append("" + model.CommonParts + ",");
            }
            if (model.Exclude != null)
            {
                strSql1.Append("Exclude,");
                strSql2.Append("" + (model.Exclude ? 1 : 0) + ",");
            }
            if (model.childCycle != null)
            {
                strSql1.Append("childCycle,");
                strSql2.Append("" + model.childCycle + ",");
            }
            if (model.childsCycle != null)
            {
                strSql1.Append("childsCycle,");
                strSql2.Append("" + model.childsCycle + ",");
            }
            if (model.depths != null)
            {
                strSql1.Append("depths,");
                strSql2.Append("" + model.depths + ",");
            }
            if (model.sDataVersion != null)
            {
                strSql1.Append("sDataVersion,");
                strSql2.Append("N'" + model.sDataVersion + "',");
            }
            if (model.bDel != null)
            {
                strSql1.Append("bDel,");
                strSql2.Append("" + (model.bDel ? 1 : 0) + ",");
            }
            strSql.Append("insert into TK_BOM(");
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

