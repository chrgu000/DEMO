using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:存货采购委外周期导入
    /// </summary>
    public partial class 存货采购委外周期导入
    {
        public 存货采购委外周期导入()
        { }


        public int Save(DataTable dt)
        {
            int iCou = 0;
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {

                string sSQL = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(!BaseFunction.BaseFunction.ReturnBool(dt.Rows[i]["choose"]))
                    {
                        continue;
                    }

                    TH.Model.Inventory_extradefine model = new TH.Model.Inventory_extradefine();
                    model.cInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                    model.cidefine1 = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["评审采购周期"]);
                    model.cidefine2 = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["评审委外周期"]);
                    model.cidefine5 = BaseFunction.BaseFunction.ReturnInt(dt.Rows[i]["质检周期"]);
                    model.cidefine8 = BaseFunction.BaseFunction.ReturnDecimal(dt.Rows[i]["经济批量"]);

                    sSQL = "select * from @u8.Inventory_extradefine where cInvCode='" + model.cInvCode + "' ";
                    DataTable dtTemp = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        sSQL = Update(model);
                    }
                    else
                    {
                        sSQL = Add(model);
                    }
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
                iCou = 0;
                throw new Exception(error.Message);
            }

            return iCou;
        }


        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from @u8.Inventory_extradefine");
            strSql.Append(" where cInvCode='" + cInvCode + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.Inventory_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cInvCode != null)
            {
                strSql1.Append("cInvCode,");
                strSql2.Append("'" + model.cInvCode + "',");
            }
            if (model.cidefine1 != null)
            {
                strSql1.Append("cidefine1,");
                strSql2.Append("" + model.cidefine1 + ",");
            }
            if (model.cidefine2 != null)
            {
                strSql1.Append("cidefine2,");
                strSql2.Append("" + model.cidefine2 + ",");
            }
           
            if (model.cidefine5 != null)
            {
                strSql1.Append("cidefine5,");
                strSql2.Append("" + model.cidefine5 + ",");
            }
          
            if (model.cidefine8 != null)
            {
                strSql1.Append("cidefine8,");
                strSql2.Append("" + model.cidefine8 + ",");
            }
           
            strSql.Append("insert into @u8.Inventory_extradefine(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.Inventory_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update @u8.Inventory_extradefine set ");
            if (model.cidefine1 != null)
            {
                strSql.Append("cidefine1=" + model.cidefine1 + ",");
            }
            else
            {
                strSql.Append("cidefine1= null ,");
            }
            if (model.cidefine2 != null)
            {
                strSql.Append("cidefine2=" + model.cidefine2 + ",");
            }
            else
            {
                strSql.Append("cidefine2= null ,");
            }
         
            if (model.cidefine5 != null)
            {
                strSql.Append("cidefine5=" + model.cidefine5 + ",");
            }
            else
            {
                strSql.Append("cidefine5= null ,");
            }
          
            if (model.cidefine8 != null)
            {
                strSql.Append("cidefine8=" + model.cidefine8 + ",");
            }
            else
            {
                strSql.Append("cidefine8= null ,");
            }
         
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where cInvCode='" + model.cInvCode + "' ");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TH.Model.Inventory_extradefine GetModel(string cInvCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" cInvCode,cidefine1,cidefine2,cidefine3,cidefine4,cidefine5,cidefine6,cidefine7,cidefine8,cidefine9 ");
            strSql.Append(" from Inventory_extradefine ");
            strSql.Append(" where cInvCode='" + cInvCode + "' ");
            TH.Model.Inventory_extradefine model = new TH.Model.Inventory_extradefine();
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
        public TH.Model.Inventory_extradefine DataRowToModel(DataRow row)
        {
            TH.Model.Inventory_extradefine model = new TH.Model.Inventory_extradefine();
            if (row != null)
            {
                if (row["cInvCode"] != null)
                {
                    model.cInvCode = row["cInvCode"].ToString();
                }
                if (row["cidefine1"] != null && row["cidefine1"].ToString() != "")
                {
                    model.cidefine1 = int.Parse(row["cidefine1"].ToString());
                }
                if (row["cidefine2"] != null && row["cidefine2"].ToString() != "")
                {
                    model.cidefine2 = int.Parse(row["cidefine2"].ToString());
                }
                if (row["cidefine3"] != null && row["cidefine3"].ToString() != "")
                {
                    model.cidefine3 = decimal.Parse(row["cidefine3"].ToString());
                }
                if (row["cidefine4"] != null)
                {
                    model.cidefine4 = row["cidefine4"].ToString();
                }
                if (row["cidefine5"] != null && row["cidefine5"].ToString() != "")
                {
                    model.cidefine5 = int.Parse(row["cidefine5"].ToString());
                }
                if (row["cidefine6"] != null && row["cidefine6"].ToString() != "")
                {
                    model.cidefine6 = int.Parse(row["cidefine6"].ToString());
                }
                if (row["cidefine7"] != null && row["cidefine7"].ToString() != "")
                {
                    model.cidefine7 = decimal.Parse(row["cidefine7"].ToString());
                }
                if (row["cidefine8"] != null && row["cidefine8"].ToString() != "")
                {
                    model.cidefine8 = decimal.Parse(row["cidefine8"].ToString());
                }
                if (row["cidefine9"] != null && row["cidefine9"].ToString() != "")
                {
                    model.cidefine9 = int.Parse(row["cidefine9"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

