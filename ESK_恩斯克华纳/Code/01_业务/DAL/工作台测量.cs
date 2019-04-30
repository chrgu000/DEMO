using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 业务.DAL
{
    /// <summary>
    /// 数据访问类:工作台测量
    /// </summary>
    public partial class 工作台测量
    {
        public 工作台测量()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(业务.Model.工作台测量 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.工作台 != null)
            {
                strSql1.Append("工作台,");
                strSql2.Append("'" + model.工作台 + "',");
            }
            if (model.发射器ID != null)
            {
                strSql1.Append("发射器ID,");
                strSql2.Append("" + model.发射器ID + ",");
            }
            if (model.量具品名 != null)
            {
                strSql1.Append("量具品名,");
                strSql2.Append("'" + model.量具品名 + "',");
            }
            if (model.班组 != null)
            {
                strSql1.Append("班组,");
                strSql2.Append("'" + model.班组 + "',");
            }
            if (model.测定项目 != null)
            {
                strSql1.Append("测定项目,");
                strSql2.Append("'" + model.测定项目 + "',");
            }
            if (model.测定项目日文 != null)
            {
                strSql1.Append("测定项目日文,");
                strSql2.Append("'" + model.测定项目日文 + "',");
            }
            if (model.规格 != null)
            {
                strSql1.Append("规格,");
                strSql2.Append("'" + model.规格 + "',");
            }
            if (model.尺寸公差 != null)
            {
                strSql1.Append("尺寸公差,");
                strSql2.Append("'" + model.尺寸公差 + "',");
            }
            if (model.下限 != null)
            {
                strSql1.Append("下限,");
                strSql2.Append("" + model.下限 + ",");
            }
            if (model.上限 != null)
            {
                strSql1.Append("上限,");
                strSql2.Append("" + model.上限 + ",");
            }
            if (model.测量值 != null)
            {
                strSql1.Append("测量值,");
                strSql2.Append("" + model.测量值 + ",");
            }
            if (model.原始值 != null)
            {
                strSql1.Append("原始值,");
                strSql2.Append("" + model.原始值 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            if (model.检验员 != null)
            {
                strSql1.Append("检验员,");
                strSql2.Append("'" + model.检验员 + "',");
            }
            if (model.检验时间 != null)
            {
                strSql1.Append("检验时间,");
                strSql2.Append("'" + model.检验时间 + "',");
            }
            if (model.操作员 != null)
            {
                strSql1.Append("操作员,");
                strSql2.Append("'" + model.操作员 + "',");
            }
            if (model.操作日期 != null)
            {
                strSql1.Append("操作日期,");
                strSql2.Append("'" + model.操作日期 + "',");
            }
            if (model.dtmCreate != null)
            {
                strSql1.Append("dtmCreate,");
                strSql2.Append("getdate(),");
            }
            if (model.SourceID != null)
            {
                strSql1.Append("SourceID,");
                strSql2.Append("" + model.SourceID + ",");
            }
            strSql.Append("insert into 工作台测量(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(业务.Model.工作台测量 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 工作台测量 set ");
            if (model.发射器ID != null)
            {
                strSql.Append("发射器ID=" + model.发射器ID + ",");
            }
            else
            {
                strSql.Append("发射器ID= null ,");
            }
            if (model.工作台 != null)
            {
                strSql.Append("工作台='" + model.工作台 + "',");
            }
            else
            {
                strSql.Append("工作台编号= null ,");
            }
            if (model.量具品名 != null)
            {
                strSql.Append("量具品名='" + model.量具品名 + "',");
            }
            else
            {
                strSql.Append("量具品名= null ,");
            }
            if (model.班组 != null)
            {
                strSql.Append("班组='" + model.班组 + "',");
            }
            else
            {
                strSql.Append("班组= null ,");
            }
            if (model.测定项目 != null)
            {
                strSql.Append("测定项目='" + model.测定项目 + "',");
            }
            else
            {
                strSql.Append("测定项目= null ,");
            }
            if (model.测定项目日文 != null)
            {
                strSql.Append("测定项目日文='" + model.测定项目日文 + "',");
            }
            else
            {
                strSql.Append("测定项目日文= null ,");
            }
            if (model.规格 != null)
            {
                strSql.Append("规格='" + model.规格 + "',");
            }
            else
            {
                strSql.Append("规格= null ,");
            }
            if (model.尺寸公差 != null)
            {
                strSql.Append("尺寸公差='" + model.尺寸公差 + "',");
            }
            else
            {
                strSql.Append("尺寸公差= null ,");
            }
            if (model.下限 != null)
            {
                strSql.Append("下限=" + model.下限 + ",");
            }
            else
            {
                strSql.Append("下限= null ,");
            }
            if (model.上限 != null)
            {
                strSql.Append("上限=" + model.上限 + ",");
            }
            else
            {
                strSql.Append("上限= null ,");
            }
            if (model.测量值 != null)
            {
                strSql.Append("测量值=" + model.测量值 + ",");
            }
            else
            {
                strSql.Append("测量值= null ,");
            }
            if (model.原始值 != null)
            {
                strSql.Append("原始值=" + model.原始值 + ",");
            }
            else
            {
                strSql.Append("原始值= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.检验员 != null)
            {
                strSql.Append("检验员='" + model.检验员 + "',");
            }
            else
            {
                strSql.Append("检验员= null ,");
            }
            if (model.检验时间 != null)
            {
                strSql.Append("检验时间='" + model.检验时间 + "',");
            }
            else
            {
                strSql.Append("检验时间= null ,");
            }
            if (model.操作员 != null)
            {
                strSql.Append("操作员='" + model.操作员 + "',");
            }
            else
            {
                strSql.Append("操作员= null ,");
            }
            if (model.操作日期 != null)
            {
                strSql.Append("操作日期='" + model.操作日期 + "',");
            }
            else
            {
                strSql.Append("操作日期= null ,");
            }
            if (model.dtmCreate != null)
            {
                strSql.Append("dtmCreate='" + model.dtmCreate + "',");
            }
            else
            {
                strSql.Append("dtmCreate= null ,");
            }
            if (model.SourceID != null)
            {
                strSql.Append("SourceID=" + model.SourceID + ",");
            }
            else
            {
                strSql.Append("SourceID= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 工作台测量 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
 
        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

