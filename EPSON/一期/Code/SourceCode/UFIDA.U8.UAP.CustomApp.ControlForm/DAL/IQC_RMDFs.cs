using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_IQC_RMDFs
    /// </summary>
    public partial class _IQC_RMDFs
    {
        public _IQC_RMDFs()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._IQC_RMDFs model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IQCNo != null)
            {
                strSql1.Append("IQCNo,");
                strSql2.Append("'" + model.IQCNo + "',");
            }
            if (model.iRow != null)
            {
                strSql1.Append("iRow,");
                strSql2.Append("" + model.iRow + ",");
            }
            if (model.Defect != null)
            {
                strSql1.Append("Defect,");
                strSql2.Append("'" + model.Defect + "',");
            }
            if (model.Qty != null)
            {
                strSql1.Append("Qty,");
                strSql2.Append("" + model.Qty + ",");
            }
            if (model.Attachment != null)
            {
                strSql1.Append("Attachment,");
                strSql2.Append("'" + model.Attachment + "',");
            }
            if (model.AttachmentName != null)
            {
                strSql1.Append("AttachmentName,");
                strSql2.Append("'" + model.AttachmentName + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.fileext != null)
            {
                strSql1.Append("fileext,");
                strSql2.Append("'" + model.fileext + "',");
            }
            strSql.Append("insert into _IQC_RMDFs(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _IQC_RMDFs ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string IQCNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _IQC_RMDFs ");
            strSql.Append(" where IQCNo='" + IQCNo + "'");
            return (strSql.ToString());
        }	
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

