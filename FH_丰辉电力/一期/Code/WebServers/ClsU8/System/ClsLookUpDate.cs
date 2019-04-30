using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsLookUpDate
    {
        string tablename = "_LookUpDate";
        string Code = "iID";
        string Name = "iText";
        string CodeTitle = "编号";
        string NameTitle = "内容";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string dt(string iType)
        {
            string s = "";

            try
            {
                sSQL = "select *,'edit' as iSave from dbo." + tablename + " where iType = '" + iType + "' order by " + Code;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string save(DataTable dtGrid, string iType)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update" || dtGrid.Rows[i]["iSave"].ToString().Trim() == "add")
                    {
                        #region 判断
                        if (dtGrid.Rows[i][Code].ToString().Trim() == ""
                            && dtGrid.Rows[i][Name].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGrid.Rows[i][Code].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + CodeTitle + "不能为空\n";
                            continue;
                        }


                        if (dtGrid.Rows[i][Name].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + NameTitle + "不能为空\n";
                            continue;
                        }
                        if (dtGrid.Rows[i]["bClose"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "是否启用不能为空\n";
                            continue;
                        }
                        if (dtGrid.Rows[i]["bSystem"].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + "是否系统不能为空\n";
                            continue;
                        }
                        #endregion

                        #region 判断是否重复
                        for (int j = 0; j < i; j++)
                        {
                            if (dtGrid.Rows[i][Code].ToString().Trim() == dtGrid.Rows[j][Code].ToString().Trim())
                            {
                                sErr = sErr + "行" + (i + 1) + CodeTitle + "重复\n";
                                continue;
                            }
                        }

                        for (int j = 0; j < i; j++)
                        {
                            if (dtGrid.Rows[i][Name].ToString().Trim() == dtGrid.Rows[j][Name].ToString().Trim())
                            {
                                sErr = sErr + "行" + (i + 1) + NameTitle + "重复\n";
                                continue;
                            }
                        }
                        #endregion
                        #region 生成table
                        DataRow dr = dt.NewRow();
                        dr[Code] =dtGrid.Rows[i][Code].ToString().Trim();
                        dr[Name] = dtGrid.Rows[i][Name].ToString().Trim();
                        dr["iType"] = iType;
                        dr["Remark"] = dtGrid.Rows[i]["Remark"];
                        dr["bClose"] = dtGrid.Rows[i]["bClose"];
                        dr["bSystem"] = dtGrid.Rows[i]["bSystem"];

                        dt.Rows.Add(dr);
                        #endregion

                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                        if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                            aList.Add(sSQL);
                        }
                    }
                }
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch(Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public string del(string iID, string iType)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                if (iType == "1")
                {
                    sSQL = "select count(1) from dbo._LookUpDate where SexID = '" + iID + "' ";
                    long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        throw new Exception("编号 " + iID + " 已经使用不能删除\n");
                    }
                }
                else if (iType == "2")
                {
                    sSQL = "select count(1) from dbo.Project where cPCCode = '" + iID + "' ";
                    long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        throw new Exception("编号 " + iID + " 已经使用不能删除\n");
                    }
                }
                else if (iType == "3")
                {
                    sSQL = "select count(1) from dbo.ProjectRecord where cRsCode = '" + iID + "' ";
                    long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou > 0)
                    {
                        throw new Exception("编号 " + iID + " 已经使用不能删除\n");
                    }
                }

                sSQL = "delete " + tablename + " where " + Code + " = '" + iID + "' and iType='" + iType + "' ";
                aList.Add(sSQL);

                if (sErr != "")
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            if (sErr == "")
            {
                return "ok";
            }
            else
            {
                return sErr;
            }
        }

        public bool bClosed(string cQCode)
        {
            string sErr = "";
            ArrayList aList = new ArrayList();
            try
            {
                sSQL = "select bClosed from " + tablename + " where " + Code + "='" + cQCode + "' ";
                string b = clsSQLCommond.ExecGetScalar(sSQL).ToString();
                if (b != "")
                {
                    return bool.Parse(b);
                }
            }
            catch (Exception ee)
            {
                sErr = ee.Message;
            }
            return false;
        }
    }
}
