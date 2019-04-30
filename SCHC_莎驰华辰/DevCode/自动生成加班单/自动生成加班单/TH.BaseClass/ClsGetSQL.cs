using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace TH.BaseClass
{
    public class ClsGetSQL
    {
        private static volatile ClsGetSQL clsGetSQL = null;
        private static object lockHelper = new object();
        TH.BaseClass.ClsDataBase clsSQL = TH.BaseClass.ClsDataBaseFactory.Instance();
        
        //        获得表中列信息
        //        select * 
        //        from UFDLImport.INFORMATION_SCHEMA.COLUMNS 
        //        where table_name = 'OMPlan' 
        //        order by table_name,ordinal_position
        public static ClsGetSQL Instance()
        {
            if (clsGetSQL == null)
            {
                lock (lockHelper)
                {
                    if (clsGetSQL == null)
                    {
                        clsGetSQL = new ClsGetSQL();
                    }
                }
            }

            return clsGetSQL;
        }

        public ArrayList GetInsertArrayList(string sDataBaseName, string sTableName, DataTable dtTemp)
        {
            ArrayList aList = new ArrayList();
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                string sSQL = GetInsertSQL(sDataBaseName, sTableName, dtTemp, i);
                aList.Add(sSQL);
            }
            return aList;
        }


        /// <summary>
        /// 组装Delete语句
        /// </summary>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetDeleteSQL(string sTableName, DataTable dtTemp, int iRow)
        {
            return GetDeleteSQL(TH.BaseClass.ClsBaseDataInfo.sDataBaseName, sTableName, dtTemp, iRow);
        }

        /// <summary>
        /// 组装Delete语句
        /// </summary>
        /// <param name="sDataBaseName">数据库名称</param>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetDeleteSQL(string sDataBaseName, string sTableName, DataTable dtTemp, int iRow)
        {
            bool bWhere = false;

            string sSQL = "select * from _TableColInfo " +
                               "WHERE TABLE_NAME = '" + sTableName + "' AND TABLE_CATALOG= '" + sDataBaseName + "' " +
                               "order by iID";
            DataTable dt = clsSQL.ExecQuery(sSQL);

            string s = "";
            string s1 = "";
            string s2 = " where 1 = 1 ";
            string s3 = "";
            string s4 = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["DATA_TYPE"].ToString().Trim())
                {
                    case "1":
                        {
                            switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                            {
                                case "":
                                    s4 = "null";
                                    break;
                                default:
                                    s4 = dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim();
                                    break;
                            }
                        }
                        break;
                    case "2":
                        {
                            switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                            {
                                case "":
                                    s4 = "null";
                                    break;
                                default:
                                    s4 = "'" + dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim() + "'";
                                    break;
                            }
                        }
                        break;
                    case "3":
                        {
                            switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                            {
                                case "false":
                                    s4 = "0";
                                    break;
                                case "true":
                                    s4 = "1";
                                    break;
                                case "":
                                    s4 = "null";
                                    break;
                            }
                        }
                        break;
                }
                s3 = dt.Rows[i]["COLUMN_NAME"].ToString().Trim();
                if (Convert.ToBoolean(dt.Rows[i]["bKey"]))
                {
                    s2 = s2 + " and " + s3 + " = " + s4;
                    bWhere = true;
                }
            }
            if (bWhere)
            {
                s = "delete " + sDataBaseName + ".." + sTableName + " " + s1 + s2;
            }
            else
            {
                throw new Exception("删除语句必须有条件，不支持删除全表");
            }
            return s;
        }

        /// <summary>
        /// 组装Update语句
        /// </summary>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetUpdateSQL(string sTableName, DataTable dtTemp, int iRow)
        {
            return GetUpdateSQL(TH.BaseClass.ClsBaseDataInfo.sDataBaseName, sTableName, dtTemp, iRow);
        }


        /// <summary>
        /// 组装Update语句
        /// </summary>
        /// <param name="sDataBaseName">数据库名称</param>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetUpdateSQL(string sDataBaseName, string sTableName, DataTable dtTemp, int iRow)
        {
            bool bWhere = false;
            string sSQL = "select * from _TableColInfo " +
                           "WHERE TABLE_NAME = '" + sTableName + "' AND TABLE_CATALOG= '" + sDataBaseName + "' " +
                           "order by iID";
            DataTable dt = clsSQL.ExecQuery(sSQL);

            string s = "";
            string s1 = "";
            string s2 = " where 1 = 1 ";
            string s3 = "";
            string s4 = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if (dt.Rows[i]["COLLATION_ADD"].ToString().Trim() != "1" && dt.Rows[i]["DATA_TYPE"].ToString().Trim() != "0")
                {

                    if (dt.Rows[i]["COLUMN_NAME"].ToString().Trim().ToLower().Trim() == "SysCreateDate".ToLower())
                        continue;

                    //gridview中不包含单据表中的列，则跳过
                    try
                    {
                        string sTemp = dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().Trim()].ToString().Trim();

                    }
                    catch
                    {
                        continue;
                    }
                    //if (s1.Trim() == string.Empty)
                    {
                        switch (dt.Rows[i]["DATA_TYPE"].ToString().Trim())
                        {
                            case "1":
                                {
                                    switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                    {
                                        case "":
                                            s4 = "null";
                                            break;
                                        default:
                                            s4 = dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim();
                                            break;
                                    }
                                }
                                break;
                            case "2":
                                {
                                    switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                    {
                                        case "":
                                            s4 = "null";
                                            break;
                                        default:
                                            s4 = "N'" + dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim() + "'";
                                            break;
                                    }
                                }
                                break;
                            case "3":
                                {
                                    switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().ToLower().Trim())
                                    {
                                        case "false":
                                            s4 = "0";
                                            break;
                                        case "true":
                                            s4 = "1";
                                            break;
                                        case "":
                                            s4 = "null";
                                            break;
                                    }
                                }
                                break;
                        }
                    }
                }
                s3 = dt.Rows[i]["COLUMN_NAME"].ToString().Trim();
                if (Convert.ToBoolean(dt.Rows[i]["bKey"]))
                {
                    s2 = s2 + " and " + s3 + " = " + s4;
                    bWhere = true;
                }
                else if(dt.Rows[i]["COLLATION_ADD"].ToString().Trim() != "1" && dt.Rows[i]["DATA_TYPE"].ToString().Trim() != "0")
                {
                    if (s1.Trim() == string.Empty)
                    {
                        s1 = s3 + " = " + s4;
                        bWhere = true;
                    }
                    else
                    {
                        s1 = s1 + "," + s3 + " = " + s4;
                        bWhere = true;
                    }
                }
            }
            if (bWhere)
            {
                s = "update " + sDataBaseName + ".." + sTableName + " set " + s1 + s2;
            }
            else
            {
                throw new Exception("更新语句必须有条件，不支持更新全表");
            }
            return s;
        }

        /// <summary>
        /// 组装个Insert语句
        /// </summary>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetInsertSQL(string sTableName, DataTable dtTemp, int iRow)
        {
            return GetInsertSQL(TH.BaseClass.ClsBaseDataInfo.sDataBaseName, sTableName, dtTemp, iRow);
        }

        /// <summary>
        /// 组装个Insert语句
        /// </summary>
        /// <param name="sDataBaseName">数据库名称</param>
        /// <param name="sTableName">表名称</param>
        /// <param name="dtTemp">表数据</param>
        /// <param name="iRow">行</param>
        /// <returns></returns>
        public string GetInsertSQL(string sDataBaseName, string sTableName, DataTable dtTemp, int iRow)
        {
            string sSQL = "select * from _TableColInfo " +
                            "WHERE TABLE_NAME = '" + sTableName + "' AND TABLE_CATALOG= '" + sDataBaseName + "' " +
                            "order by iID";
            DataTable dt = clsSQL.ExecQuery(sSQL);

            string s= "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            s1 = "insert into " + sDataBaseName + ".." + sTableName + "(";
            s2 = ")values(" + "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["COLLATION_ADD"].ToString().Trim() == "1")
                {
                    continue;
                }
                if (dt.Rows[i]["DATA_TYPE"].ToString().Trim() == "0")
                {
                    continue;
                }

                if (dt.Rows[i]["COLUMN_NAME"].ToString().Trim().ToLower() == "SysCreateDate".ToLower())
                    continue;

                //gridview中不包含单据表中的列，则跳过
                try
                {
                    string sTemp = dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().Trim()].ToString().Trim();
                }
                catch
                {
                    continue;
                }

                if (s3.Trim() == string.Empty)
                {
                    switch (dt.Rows[i]["DATA_TYPE"].ToString().Trim())
                    {
                        case "1":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                {
                                    case "":
                                        s4 =  "null";
                                        break;
                                    default:
                                        s4 = dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim();
                                        break;
                                }
                            }
                            break;
                        case "2":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                {
                                    case "":
                                        s4 = "null";
                                        break;
                                    default:
                                        s4 = "N'" + dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim() + "'";
                                        break;
                                }
                            }
                            break;
                        case "3":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                {
                                    case "false":
                                        s4 = "0";
                                        break;
                                    case "true":
                                        s4 = "1";
                                        break;
                                    case "":
                                        s4 = "null";
                                        break;
                                }
                            }
                            break;
                    }

                    s3 = dt.Rows[i]["COLUMN_NAME"].ToString().Trim();
                }
                else
                {
                    switch (dt.Rows[i]["DATA_TYPE"].ToString().Trim())
                    {
                        case "1":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim().ToLower())
                                {
                                    case "":
                                        s4 = s4 + ",null";
                                        break;
                                    default:
                                        s4 = s4 + "," + dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim();
                                        break;
                                }
                            }
                            break;
                        case "2":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim())
                                {
                                    case "":
                                        s4 = s4 + ",null";
                                        break;
                                    default: s4 = s4 + ",N'" + dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim() + "'";
                                        break;
                                }
                            }
                            break;
                        case "3":
                            {
                                switch (dtTemp.Rows[iRow][dt.Rows[i]["COLUMN_NAME"].ToString().ToLower().Trim()].ToString().Trim().ToLower())
                                {
                                    case "false":
                                        s4 =  s4 + ",0";
                                        break;
                                    case "true":
                                        s4 = s4 + ",1";
                                        break;
                                    case "1":
                                        s4 = s4 + ",1";
                                        break;
                                    case "0":
                                        s4 = s4 + ",0";
                                        break;
                                    case "":
                                        s4 = s4 + ",null";
                                        break;
                                }
                            }
                            break;
                    }

                    s3 = s3 + "," + dt.Rows[i]["COLUMN_NAME"];

                }
            }
            s = s1 + s3 + s2 + s4 + ")";
            return s;
        }


        public DataTable GetLookUpEdit(string s)
        {
            try
            {
                DataTable dt = clsSQL.ExecQuery(s);
                int iCol = dt.Columns.Count;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < iCol; i++)
                {
                    dr[i] = DBNull.Value;
                }
                dt.Rows.Add(dr);
                DataView dv = dt.DefaultView;
                dv.Sort = "iID asc";

                return dv.Table;
            }
            catch (Exception ee)
            {
                throw new Exception("获得列表失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 设置现存量
        /// </summary>
        /// <param name="sInvCode"></param>
        /// <param name="sWhCode"></param>
        /// <param name="dQty"></param>
        /// <param name="dNum"></param>
        /// <returns></returns>
        public string SetCurrQty(string sInvCode, string sWhCode, double dQty, double dNum)
        {
            string sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + sInvCode + "' and cWhCode = '" + sWhCode + "') " +
                                 "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + (" + dQty + "),iNum = isnull(iNum,0) + (" + dNum + ")  where cInvCode = '" + sInvCode + "' and cWhCode = '" + sWhCode + "' " +
                             "else " +
                             "begin " +
                                 "declare @itemid varchar(20); " +
                                 "declare @iCount int;  " +
                                 "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + sInvCode + "';   " +
                                 "if( @iCount > 0 ) " +
                                     "select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + sInvCode + "';  " +
                                 "else  " +
                                     "select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                 "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('" + sWhCode + "','" + sInvCode + "'," + dQty + "," + dNum + ",@itemid) " +
                             "end";

            return sSQL;
        }

        /// <summary>
        /// 设置现存量
        /// </summary>
        /// <param name="sInvCode"></param>
        /// <param name="sWhCode"></param>
        /// <param name="dQty"></param>
        /// <returns></returns>
        public string SetCurrQty(string sInvCode, string sWhCode, double dQty)
        {
            string sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + sInvCode + "' and cWhCode = '" + sWhCode + "') " +
                                 "update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + (" + dQty + ")  where cInvCode = '" + sInvCode + "' and cWhCode = '" + sWhCode + "' " +
                             "else " +
                             "begin " +
                                 "declare @itemid varchar(20); " +
                                 "declare @iCount int;  " +
                                 "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + sInvCode + "';   " +
                                 "if( @iCount > 0 ) " +
                                     "select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + sInvCode + "';  " +
                                 "else  " +
                                     "select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                 "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + sWhCode + "','" + sInvCode + "'," + dQty + ",@itemid) " +
                             "end";

            return sSQL;
        }
    }

}
