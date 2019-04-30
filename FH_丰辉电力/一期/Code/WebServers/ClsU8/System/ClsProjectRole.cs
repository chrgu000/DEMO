using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsProjectRole
    {
        string tablename = "ProjectRole";
        string Code = "vchrUid";
        string CodeTitle = "用户编码";
        string sSQL = "";
        protected ClsGetSQL clsGetSQL = ClsGetSQL.Instance();
        protected ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();
        public string dt()
        {
            string s = "";

            try
            {
                sSQL = @"select a.vchrUid, a.vchrName,isnull(S1,'1') as S1, isnull(S2,'1') as S2, isnull(S3,'1') as S3, isnull(S4,'1') as S4, isnull(S5,'1') as S5, isnull(S6,'1') as S6, 
                isnull(S7,'1') as S7, isnull(S8,'1') as S8, isnull(S9,'1') as S9,  isnull(B1,0) as B1, isnull(B2,0) as B2, case when b.vchrUid is null then 'add' else 'edit' end as iSave from _UserInfo a left join " + tablename + " b on a.vchrUid=b.vchrUid";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string save(DataTable dtGrid)
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
                        if (dtGrid.Rows[i][Code].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dtGrid.Rows[i][Code].ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + CodeTitle + "不能为空\n";
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
                        #endregion
                        #region 生成table
                        DataRow dr = dt.NewRow();
                        dr[Code] = dtGrid.Rows[i][Code].ToString().Trim();
                        dr["B2"] = dtGrid.Rows[i]["B2"].ToString().Trim();
                        dr["B1"] = dtGrid.Rows[i]["B1"].ToString().Trim();
                        dr["S1"] = dtGrid.Rows[i]["S1"].ToString().Trim();
                        dr["S2"] = dtGrid.Rows[i]["S2"].ToString().Trim();
                        dr["S3"] = dtGrid.Rows[i]["S3"].ToString().Trim();
                        dr["S4"] = dtGrid.Rows[i]["S4"].ToString().Trim();
                        dr["S5"] = dtGrid.Rows[i]["S5"].ToString().Trim();
                        dr["S6"] = dtGrid.Rows[i]["S6"].ToString().Trim();
                        dr["S7"] = dtGrid.Rows[i]["S7"].ToString().Trim();
                        dr["S8"] = dtGrid.Rows[i]["S8"].ToString().Trim();
                        dr["S9"] = dtGrid.Rows[i]["S9"].ToString().Trim();
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

        //public string del(DataTable dtGrid)
        //{
        //    string sErr = "";
        //    ArrayList aList = new ArrayList();
        //    try
        //    {
        //        for (int i = 0; i < dtGrid.Rows.Count; i++)
        //        {
        //            if (dtGrid.Rows[i]["iSave"].ToString().Trim() == "del")
        //            {
        //                string CodeID = dtGrid.Rows[i][Code].ToString().Trim();
        //                sSQL = "select count(1) from dbo.Project where " + Code + " = '" + CodeID + "' ";
        //                long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
        //                if (iCou > 0)
        //                {
        //                    sErr = "行" + (i + 1).ToString() + " " + CodeID + " 已经使用不能删除\n";
        //                    continue;
        //                }

        //                sSQL = "delete " + tablename + " where " + Code + " = '" + CodeID + "' ";
        //                aList.Add(sSQL);
        //            }
        //        }
        //        if (sErr != "")
        //        {
        //            throw new Exception(sErr);
        //        }
        //        if (aList.Count > 0)
        //        {
        //            int iCou = clsSQLCommond.ExecSqlTran(aList);
        //        }
        //        return sErr;
        //    }
        //    catch (Exception ee)
        //    {
        //        sErr = ee.Message;
        //    }
        //    return sErr;
        //}

        //public bool bClosed(string cECode)
        //{
        //    string sErr = "";
        //    ArrayList aList = new ArrayList();
        //    try
        //    {
        //        sSQL = "select bClosed from " + tablename + " where " + Code + "='" + cECode + "' ";
        //        string b = clsSQLCommond.ExecGetScalar(sSQL).ToString();
        //        if (b != "")
        //        {
        //            return bool.Parse(b);
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        sErr = ee.Message;
        //    }
        //    return false;
        //}

        public string dtrole(string vchrUid)
        {
            string s = "";

            try
            {
                sSQL = @"select * from " + tablename + " where vchrUid='" + vchrUid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
