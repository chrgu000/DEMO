using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace FrameBaseFunction
{
    /// <summary>
    /// SQL 语句组装工厂
    /// </summary>
    public class ClsSQLFactory
    {
        FrameBaseFunction.ClsDataBase clsSQL = FrameBaseFunction.ClsDataBaseFactory.Instance();
        private static volatile ClsSQLFactory clsSQLFactory = null;
        private static object lockHelper = new object();


        public static ClsSQLFactory Instance()
        {
            if (clsSQLFactory == null)
            {
                lock (lockHelper)
                {
                    if (clsSQLFactory == null)
                    {
                        clsSQLFactory = new ClsSQLFactory();
                    }
                }
            }

            return clsSQLFactory;
        }

        /// <summary>
        /// 组装SQL语句
        /// </summary>
        /// <param name="sTableName">表名称</param>
        /// <param name="dt2">表值</param>
        /// <returns></returns>
        public ArrayList sExecInsertSQL(string sTableName, DataTable dt2)
        {
            ArrayList aList = new ArrayList();
            try
            {
                string sSQL = "select * from information_schema.columns where table_name = '" + sTableName + "'";
                DataTable dt1 = clsSQL.ExecQuery(sSQL);
                if (dt1.Rows.Count < 1)
                {
                    throw new Exception("未找到该数据库表结构信息！");
                }

                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    bool bFisrt = true;
                    string sSQL1 = "insert into " + dt1.Rows[0]["dtName"].ToString().Trim() + "(";
                    string sSQL2 = "values(";
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        string sColName = dt1.Rows[i]["column_name"].ToString().Trim();
                        int iValueType = iAddCol(dt1.Rows[i]["data_type"].ToString().ToLower().Trim());
                        object oValue = dt2.Rows[j][sColName];
                        if (oValue == null || iValueType == 0)
                        {
                            continue;
                        }

                        if (bFisrt)
                        {
                            sSQL1 = sSQL1 + oValue;
                            if (iValueType == 2)
                            {
                                sSQL2 = sSQL2 + "'" + oValue.ToString().Trim() + "'";
                            }
                            if (iValueType == 1)
                            {
                                sSQL2 = sSQL2 + oValue.ToString().Trim();
                            }
                            bFisrt = false;
                        }
                        else
                        {
                            sSQL1 = sSQL1 + "," + oValue;

                            if (iValueType == 2)
                            {
                                sSQL2 = sSQL2 + ",'" + oValue.ToString().Trim() + "'";
                            }
                            if (iValueType == 1)
                            {
                                sSQL2 = sSQL2 + "," + oValue.ToString().Trim();
                            }
                        }
                    }
                    sSQL1 = sSQL1 + ")";
                    sSQL2 = sSQL2 + ")";
                    aList.Add(sSQL1 + sSQL2);
                }

            }
            catch(Exception ee)
            {
                throw new Exception("组装SQL语句失败，原因如下：\n  " + ee.Message);
            }
            return aList;
        }
        
        /// <summary>
        /// 判断是否添加字段：0 不添加字段，1 添加数字型字段，2 添加字符型字段
        /// </summary>
        /// <returns></returns>
        private int iAddCol(string sDataType)
        {
            int i = 0;
            switch (sDataType)
            {
                case "int":
                case "bit":
                case "float":
                case "decimal":
                case "smallint":
                case "numeric":
                case "money":
                    i = 1;
                    break;
                default:
                    i = 2;
                    break;
            }
            return i;
        }
    }
}
