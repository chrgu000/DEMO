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
    public partial class BarCodeList
    {
        public BarCodeList()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.BarCodeList model)
        {
      
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.WorkCode != null)
			{
				strSql1.Append("WorkCode,");
				strSql2.Append("'"+model.WorkCode+"',");
			}
			if (model.WorkDetailsID != null)
			{
				strSql1.Append("WorkDetailsID,");
				strSql2.Append(""+model.WorkDetailsID+",");
			}
			if (model.BarCode != null)
			{
				strSql1.Append("BarCode,");
				strSql2.Append("'"+model.BarCode+"',");
			}
			if (model.cInvCode != null)
			{
				strSql1.Append("cInvCode,");
				strSql2.Append("'"+model.cInvCode+"',");
			}
			if (model.WorkQty != null)
			{
				strSql1.Append("WorkQty,");
				strSql2.Append(""+model.WorkQty+",");
			}
			if (model.iQty != null)
			{
				strSql1.Append("iQty,");
				strSql2.Append(""+model.iQty+",");
			}
			if (model.iBoxQty != null)
			{
				strSql1.Append("iBoxQty,");
				strSql2.Append(""+model.iBoxQty+",");
			}
			if (model.Ramark != null)
			{
				strSql1.Append("Ramark,");
				strSql2.Append("'"+model.Ramark+"',");
			}
			if (model.Ramark2 != null)
			{
				strSql1.Append("Ramark2,");
				strSql2.Append("'"+model.Ramark2+"',");
			}
			strSql.Append("insert into BarCodeList(");
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
            strSql.Append("delete from BarCodeList ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }
        

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.BarCodeList GetModel(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
			strSql.Append(" iID,WorkCode,WorkDetailsID,BarCode,cInvCode,WorkQty,iQty,iBoxQty,Ramark,Ramark2 ");
            strSql.Append(" from BarCodeList ");
            strSql.Append(" where iID=" + iID + "");
            TH.Model.BarCodeList model = new TH.Model.BarCodeList();
           DataTable dt = DbHelperSQL.Query(strSql.ToString());
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.BarCodeList DataRowToModel(DataRow row)
        {
            TH.Model.BarCodeList model = new TH.Model.BarCodeList();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["WorkCode"] != null)
                {
                    model.WorkCode = row["WorkCode"].ToString();
                }
                if (row["WorkDetailsID"] != null && row["WorkDetailsID"].ToString() != "")
                {
                    model.WorkDetailsID = int.Parse(row["WorkDetailsID"].ToString());
                }
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["WorkQty"] != null && row["WorkQty"].ToString() != "")
                {
                    model.WorkQty = decimal.Parse(row["WorkQty"].ToString());
                }
                if (row["iQty"] != null && row["iQty"].ToString() != "")
                {
                    model.iQty = decimal.Parse(row["iQty"].ToString());
                }
                if (row["iBoxQty"] != null && row["iBoxQty"].ToString() != "")
                {
                    model.iBoxQty = decimal.Parse(row["iBoxQty"].ToString());
                }
               
				if(row["Ramark"]!=null)
				{
					model.Ramark=row["Ramark"].ToString();
				}
				if(row["Ramark2"]!=null)
				{
					model.Ramark2=row["Ramark2"].ToString();
				}
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

